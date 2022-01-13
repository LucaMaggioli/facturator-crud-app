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
        private readonly IVendorDataProvider _vendorDataProvider;
        private readonly ILoginDataProvider _loginDataProvider;
        private readonly IBillDataProvider _billDataProvider;
        //private readonly IClientDataProvider _clientDataProvider;
        //private readonly IArticleDataProvider _articleDataProvider;

        public VendorController(IVendorDataProvider vendorDataProvider, ILoginDataProvider loginDataProvider, IBillDataProvider billDataProvider, IClientDataProvider clientDataProvider, IArticleDataProvider articleDataProvider)
        {
            _vendorDataProvider = vendorDataProvider;
            _loginDataProvider = loginDataProvider;
            _billDataProvider = billDataProvider;
            //_clientDataProvider = clientDataProvider;
            //_articleDataProvider = articleDataProvider;
        }

        [HttpPost("singin")]
        public async Task<IActionResult> VendorSingin([FromBody] SinginBody body)
        {

            if (await _loginDataProvider.UserNameExists(body.Username))
            {
                return StatusCode(501, "username not available, choose another one");
            }
            else
            {
                Vendor newVendor = new Vendor(body.FirstName, body.LastName, body.CompanyName, body.Address, body.Email, body.Iban);
                var vendorSingedIn = await _loginDataProvider.VendorSingin(body.Username, body.Password, newVendor);
                var vendorDto = new VendorDto { };
                var vendorDtoFromVendor = new VendorDto(vendorSingedIn);
                //vendorDto.VendorDtoFromVendor(vendorSingedIn);
                return Ok(vendorDtoFromVendor);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> VendorLogin([FromBody] LoginBody body)
        {
            var vendorLoggedIn = await _loginDataProvider.VendorLogin(body.Username, body.Password);
            
            if (vendorLoggedIn != null)
            {
                var billsForVendor = await _vendorDataProvider.GetBillsForVendor(vendorLoggedIn.Id);
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
            var vendor = await _vendorDataProvider.GetVendorById(id);

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
            var updatedVendor = await _vendorDataProvider.UpdateVendor(id, vendorToUpdate);

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
            if (await _vendorDataProvider.GetFullVendorById(id) == null)
            {
                return StatusCode(503, "vendor not found with the given Id");
            }
            
            var clients = await _vendorDataProvider.GetVendorClients(id);

            var clientsDto = new List<ClientDto>();
            clients.ForEach(c => { clientsDto.Add(new ClientDto(c)); });
            
            return Ok(clientsDto);
        }

        [HttpPost("{id:int}/client")]
        public async Task<VendorDto> AddClient(int id, [FromBody] ClientBody body)
        {
            var vendor = await _vendorDataProvider.GetFullVendorById(id);
            vendor = await _vendorDataProvider.AddClientToVendor(vendor, body.FirstName, body.LastName, body.Address, body.Email);

            return new VendorDto(vendor);
        }

        [HttpGet("{id:int}/articles")]
        public async Task<IActionResult> GetArticles(int id)
        {
            var vendor = await _vendorDataProvider.GetFullVendorById(id);
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
            var vendor = await _vendorDataProvider.GetFullVendorById(id);
            if (vendor == null)
            {
                return StatusCode(503, "vendor not found with the given Id");
            }

            //var article = await new ArticleDataProvider(_context).AddArticleToVendor(articleDto.Name, articleDto.PhotoUrl, articleDto.Price, articleDto.Description);
            var article = new Article(articleDto.Name, articleDto.PhotoUrl, articleDto.Price, articleDto.Description);
            vendor = await _vendorDataProvider.AddArticleToVendor(vendor, article);

            return Ok(new VendorDto(vendor));
        }

        [HttpPost("{id:int}/bill")]
        public async Task<BillDto> AddBill(int id, [FromBody]BillBody body)
        {
            var articles = body.ArticlesIds.Select(a => new Article(a)).ToList();
            var client = new Client(body.ClientId);
            Vendor vendor = await _vendorDataProvider.GetVendorById(id);

            DateTime date = DateTime.Now;//TODO change and take it from the front
            var addedBill = await _billDataProvider.AddFullBill(date, body.IsPayed, vendor, client, articles);

            return new BillDto(addedBill);
        }

        [HttpGet("{id:int}/bills")]
        public async Task<IActionResult> GetBills(int id)
        {
            var vendor = await  _vendorDataProvider.GetFullVendorById(id);
            if (vendor == null)
            {
                return StatusCode(503, "vendor not found with the given Id");
            }

            var bills = await _vendorDataProvider.GetBillsForVendor(id);
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
