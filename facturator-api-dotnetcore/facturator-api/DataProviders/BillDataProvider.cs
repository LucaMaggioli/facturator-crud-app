using facturator_api.Models;
using facturator_api.Models.Context;
using facturator_api.Models.Dtos;
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

        public async Task<Bill> Add(Bill bill)
        {
            var addedBill = _facturatorDbContext.Bills.Add(bill);
            await SaveChanges();
            return addedBill.Entity;
        }

        internal async Task<Bill> AddArticles(Bill bill, List<Article> articles)
        {
            articles.ForEach(article => { bill.Articles.Add(article); });
            await SaveChanges();
            return bill;
        }

        internal async Task<Bill> SetBillClient(Bill bill, Client client)
        {
            bill.Client = client;
            await SaveChanges();
            return bill;
        }

        internal async Task<Bill> SetBillVendor(Bill bill, Vendor vendor)
        {
            bill.Vendor = vendor;
            await SaveChanges();
            return bill;
        }

        private async Task SaveChanges()
        {
            await _facturatorDbContext.SaveChangesAsync();
        }

        //internal Task Add(object firstName, object lastName, object address, object email)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
