using facturator_api.DataProviders;
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
        private readonly IBillDataProvider _billDataProvider;
        /// <summary>
        /// billDataProvider will be injected into controller in Startup
        /// </summary>
        /// <param name="billDataProvider"></param>
        public BillController(BillDataProvider billDataProvider)
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
        [HttpPatch("{id:int}")]
        public async Task<IActionResult> AddBill(int id)
        {
            var bill = await _billDataProvider.GetBillById(id);
            return Ok(bill);
        }

    }
}
