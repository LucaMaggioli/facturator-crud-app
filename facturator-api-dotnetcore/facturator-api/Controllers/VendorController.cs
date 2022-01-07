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
            Vendor newVendor = new Vendor(body.FirstName, body.LastName, body.CompanyName, body.Address, body.Email, body.Iban);

            if (await new LoginDataProvider(_context).UserNameExists(body.Username))
            {
                return StatusCode(501, "username not available, choose another one");
            }
            else
            {
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
                return Ok(vendorLoggedIn);
            }
            else
            {
                return StatusCode(502, "Password or username incorrect");
            }
        }

        [HttpGet("{id:int}/clients")]
        public async Task<IActionResult> VendorClients(int id) //async Task<IActionResult> 
        {
            if (await new VendorDataProvider(_context).GetVendorByIdAsync(id) == null)
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
            var vendor = await new VendorDataProvider(_context).GetVendorByIdAsync(id);
            vendor = await new VendorDataProvider(_context).AddClientToVendor(vendor, client);

            return new VendorDto(vendor);
        }

        [HttpGet("{id:int}/articles")]
        public async Task<IActionResult> GetArticles(int id)
        {
            if (await new VendorDataProvider(_context).GetVendorByIdAsync(id) == null)
            {
                return StatusCode(503, "vendor not found with the given Id");
            }

            var clients = await new VendorDataProvider(_context).GetVendorClients(id);

            var clientsDto = new List<ClientDto>();
            clients.ForEach(c => { clientsDto.Add(new ClientDto(c)); });

            return Ok(clientsDto);
        }

        [HttpPost("{id:int}/bill")]
        public async Task<VendorDto> AddBill(int id, [FromBody] BillDto body)
        {
            List<Article> articles = body.Articles
                .Select(article => new Article(article.Name, article.PhotoUrl, article.Price,article.Description,article.Id) )
                .ToList();
            Client client = new Client(body.Client.FirstName, body.Client.LastName, body.Client.Address, body.Client.Email);
            //Vendor vendor = new Vendor(body.Vendor.FirstName, body.Vendor.LastName, body.Vendor.CompanyName, body.Vendor.Address, body.Vendor.Email, body.Vendor.Iban);
            Vendor vendor = await new VendorDataProvider(_context).GetVendorByIdAsync(id);

            var bill = new Bill(body.Date, body.IsPayed, articles, client, vendor);
            var addedBill = await new BillDataProvider(_context).Add(bill);
            
            vendor = await new VendorDataProvider(_context).AddBillToVendor(vendor, bill);

            return new VendorDto(vendor);
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
