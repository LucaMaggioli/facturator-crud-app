using facturator_api.Controllers.Bodys;
using facturator_api.DataProviders;
using facturator_api.Models;
using facturator_api.Models.Context;
using facturator_api.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace facturator_api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class VendorController : Controller
    {
        private readonly FacturatorDbContext _context;
        public VendorController(FacturatorDbContext context)
        {
            _context = context;
        }

        [HttpPost("singin")]
        public async Task<IActionResult> VendorSingin([FromBody] SinginBody body)
        {

            if (await new LoginDataProvider(_context).UserNameExists(body.Username))
            {
                return StatusCode(501, "username not available, choose another one");
            }
            else
            {
                Vendor newVendor = new Vendor(body.FirstName, body.LastName, body.CompanyName, body.Address, body.Email, body.Iban);
                var vendorSingedIn = await new LoginDataProvider(_context).VendorSingin(body.Username, body.Password, newVendor);
                var vendorDto = new VendorDto { };
                var vendorDtoFromVendor = new VendorDto(vendorSingedIn);
                //vendorDto.VendorDtoFromVendor(vendorSingedIn);
                return Ok(vendorDtoFromVendor);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> VendorLogin([FromBody] LoginBody body)
        {
            var vendorLoggedIn = await new LoginDataProvider(_context).VendorLogin(body.Username, body.Password);
            
            if (vendorLoggedIn != null)
            {
                var billsForVendor = await new BillDataProvider(_context).GetBillsForVendor(vendorLoggedIn.Id);
                var vendorDto = new VendorDto(vendorLoggedIn);
                vendorDto.Bills = billsForVendor.Select(b => new BillDto(b)).ToList();
                return Ok(vendorDto);
            }
            else
            {
                return StatusCode(502, "Password or username incorrect");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetVendorData(int id)
        {
            var vendor = await new VendorDataProvider(_context).GetVendorById(id);

            if (vendor != null)
            {
                return Ok(new VendorDto(vendor));
            }
            else
            {
                return StatusCode(404, "Vendor not found for given Id");
            }
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> UpdateVendor(int id, VendorDto updatedVendorDto)
        {
            var vendorToUpdate = new Vendor(updatedVendorDto.FirstName, updatedVendorDto.LastName, updatedVendorDto.CompanyName, updatedVendorDto.Address, updatedVendorDto.Email, updatedVendorDto.Iban);
            var updatedVendor = await new VendorDataProvider(_context).UpdateVendor(id, vendorToUpdate);

            if (updatedVendor != null)
            {
                return Ok(new VendorDto(updatedVendor));
            }
            else
            {
                return StatusCode(404, "Vendor not found for given Id");
            }
        }

        [HttpGet("{id:int}/clients")]
        public async Task<IActionResult> VendorClients(int id) //async Task<IActionResult> 
        {
            if (await new VendorDataProvider(_context).GetFullVendorById(id) == null)
            {
                return StatusCode(503, "vendor not found with the given Id");
            }
            
            var clients = await new VendorDataProvider(_context).GetVendorClients(id);

            var clientsDto = new List<ClientDto>();
            clients.ForEach(c => { clientsDto.Add(new ClientDto(c)); });
            
            return Ok(clientsDto);
        }

        [HttpPost("{id:int}/client")]
        public async Task<VendorDto> AddClient(int id, [FromBody] ClientBody body)
        {
            var client = await new ClientDataProvider(_context).Add(body.FirstName, body.LastName, body.Address, body.Email);
            var vendor = await new VendorDataProvider(_context).GetFullVendorById(id);
            vendor = await new VendorDataProvider(_context).AddClientToVendor(vendor, client);

            return new VendorDto(vendor);
        }

        [HttpGet("{id:int}/articles")]
        public async Task<IActionResult> GetArticles(int id)
        {
            var vendor = await new VendorDataProvider(_context).GetFullVendorById(id);
            if (vendor == null)
            {
                return StatusCode(503, "vendor not found with the given Id");
            }

            var articlesDto = new List<ArticleDto>();
            vendor.Articles.ForEach(article => { articlesDto.Add(new ArticleDto(article)); });

            return Ok(articlesDto);
        }

        [HttpPost("{id:int}/article")]
        public async Task<IActionResult> AddArticle(int id, [FromBody] ArticleDto articleDto)
        {
            var vendor = await new VendorDataProvider(_context).GetFullVendorById(id);
            if (vendor == null)
            {
                return StatusCode(503, "vendor not found with the given Id");
            }

            var article = await new ArticleDataProvider(_context).AddArticle(articleDto.Name, articleDto.PhotoUrl, articleDto.Price, articleDto.Description);
            vendor = await new VendorDataProvider(_context).AddArticleToVendor(vendor, article);

            return Ok(new VendorDto(vendor));
        }

        [HttpPost("{id:int}/bill")]
        //public async Task<VendorDto> AddBill(int id, [FromBody] BillDto body)
        public async Task<BillDto> AddBill(int id, [FromBody] BillBody body)
        {
            //How can I do that in One Line?? (why the commented line doesn't work?)
            //List<Article> articles = body.ArticlesIds.Select(async aId => await new ArticleDataProvider(_context).GetArticleAsync(aId)).ToList();
            List<Article> articles = new List<Article>();
            body.ArticlesIds.ForEach(async aId => articles.Add(await new ArticleDataProvider(_context).GetArticleAsync(aId)));


            var client = await new ClientDataProvider(_context).GetClientById(body.ClientId);
            //the 2 below are the same, what should I do?
            //var vendor1 = await new VendorDataProvider(_context).GetVendorById(body.Vendorid);
            Vendor vendor = await new VendorDataProvider(_context).GetVendorById(id);

            DateTime date = DateTime.Now;
            var bill = new Bill(date, body.IsPayed);
            var addedBill = await new BillDataProvider(_context).Add(bill);
            addedBill = await new BillDataProvider(_context).AddArticles(bill, articles);
            addedBill = await new BillDataProvider(_context).SetBillClient(bill, client);
            addedBill = await new BillDataProvider(_context).SetBillVendor(bill, vendor);

            //vendor = await new VendorDataProvider(_context).AddBillToVendor(vendor, bill);

            return new BillDto(addedBill);
        }

        [HttpGet("{id:int}/bills")]
        public async Task<IActionResult> GetBills(int id)
        {
            var vendor = await new VendorDataProvider(_context).GetFullVendorById(id);
            if (vendor == null)
            {
                return StatusCode(503, "vendor not found with the given Id");
            }

            var bills = await new BillDataProvider(_context).GetBillsForVendor(id);
            var billsDto = bills.Select(b => new BillDto(b)).ToList();

            return Ok(bills);
        }
    }

    public class SinginBody
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Iban { get; set; }

    }

    public class LoginBody
    {
        public string Username { get; set; }
        public string Password{ get; set; }
    }
}
