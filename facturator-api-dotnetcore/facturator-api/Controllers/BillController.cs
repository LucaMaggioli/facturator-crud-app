using facturator_api.DataProviders;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace facturator_api.Controllers
{
    public class BillController : Controller
    {
        private readonly IBillDataProvider _billDataProvider;
        /// <summary>
        /// Constructor will inject into the constructor an object with type IbillDataProvider, thanks to AddTransient<> into Startup.cs
        /// </summary>
        /// <param name="billDataProvider"></param>
        public BillController(BillDataProvider billDataProvider)
        {
            _billDataProvider = billDataProvider;
        }

    }
}
