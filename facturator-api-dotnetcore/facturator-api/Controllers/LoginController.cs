using facturator_api.DataProviders;
using facturator_api.Models;
using facturator_api.Models.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace facturator_api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly FacturatorDbContext _context;
        public LoginController(FacturatorDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        //public async Task<Vendor> VendorSingin([FromBody] SinginBody body)
        public async Task<IActionResult> VendorSingin([FromBody] SinginBody body)
        {
            Vendor newVendor = new Vendor(body.FirstName, body.LastName, body.CompanyName, body.Address, body.Email, body.Iban);
            
            if(await new LoginDataProvider(_context).UserNameExists(body.Username))
            {
                return StatusCode(501, "username already exists");
            }
            else
            {
                var vendorSingedIn = await new LoginDataProvider(_context).VendorSingin(body.Username, body.Password, newVendor);
                return Ok(vendorSingedIn);
            }
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
}
