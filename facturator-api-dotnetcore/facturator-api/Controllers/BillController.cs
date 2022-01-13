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
    public class BillController : Controller
    {
        /// <summary>
        /// billDataProvider and context will be injected into controller in Startup
        /// </summary>
        /// <param name="billDataProvider"></param>
        private readonly IBillDataProvider _billDataProvider;

        public BillController(IBillDataProvider billDataProvider)
        {
            _billDataProvider = billDataProvider;
        }

        // Call this enpoint to get a Bill bi Id
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBill(int id)
        {
            var bill = await _billDataProvider.GetBillById(id);
            if(bill != null)
            {
                return Ok(bill);
            }
            else
            {
                return StatusCode(404, "bill not found");
            }
        }

        // Call this enpoint to Update a Bill by its' Id
        [HttpPost]
        public async Task<IActionResult> AddBill([FromBody] BillBody billBody)
        {
            var articles = billBody.ArticlesIds.Select(a => new Article(a)).ToList();
            Client client = new Client(billBody.ClientId);
            var vendor = new Vendor(billBody.VendorId);
            //var client = await _clientDataProvider.GetClientById(billBody.ClientId);
            //var vendor = await _vendorDataProvider.GetVendorById(billBody.VendorId);

            var bill = await _billDataProvider.AddFullBill(billBody.Date, billBody.IsPayed, vendor, client, articles);

            return Ok(bill);
        }

        // Call this enpoint to Update a Bill by its' Id
        [HttpPatch("{id:int}")]
        public async Task<IActionResult> UpdateBill(int id, [FromBody] BillDto billDto)
        {
            var bill = await _billDataProvider.GetBillById(id);
            return Ok(bill);
        }

    }
}
