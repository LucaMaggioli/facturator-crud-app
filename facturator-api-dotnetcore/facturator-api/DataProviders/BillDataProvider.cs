using facturator_api.Models;
using facturator_api.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace facturator_api.DataProviders
{
    public class BillDataProvider : IBillDataProvider
    {
        private readonly FacturatorDbContext _facturatorDbContext;

        public BillDataProvider(FacturatorDbContext context)
        {
            _facturatorDbContext = context;
        }

        /// <summary>
        /// Get a bill by it's Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Bill> GetBillById(int id)
        {
            var bill = await _facturatorDbContext.Bills.FindAsync(id);
            return bill;
        }
    }
}
