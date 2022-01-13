using facturator_api.Models;
using facturator_api.Models.Context;
using facturator_api.Models.Dtos;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Bill> AddFullBill(DateTime Date, bool IsPayed, Vendor vendor, Client client, List<Article> articles)
        {
            Bill newBill = new Bill(Date, IsPayed, articles, client, vendor);
            var addedBill = _facturatorDbContext.Bills.Add(newBill);
            await SaveChanges();
            return addedBill.Entity;
        }

        public async Task<Bill> AddFullBill2(DateTime Date, bool IsPayed, int vendorId, int clientId, List<int> articlesIds)
        {
            Bill newBill = new Bill(Date, IsPayed);

            var vendor = await new VendorDataProvider(_facturatorDbContext).GetVendorById(vendorId);
            var client = await new ClientDataProvider(_facturatorDbContext).GetClientById(clientId);
            

            var addedBill = _facturatorDbContext.Bills.Add(newBill);
            await SaveChanges();
            return addedBill.Entity;
        }

        internal async Task<Bill> AddArticles(Bill bill, List<Article> articles)
        {
            articles.ForEach(article => { bill.Articles.Add(article); bill.Total += article.Price; });
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
    }
}
