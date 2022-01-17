using facturator_api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace facturator_api.DataProviders
{
    public interface IBillDataProvider
    {
        Task<Bill> Add(Bill bill);
        Task<Bill> AddFullBill(DateTime Date, bool IsPayed, Vendor vendor, Client client, List<Article> articles);
        Task<Bill> GetBillById(int id);
        Task<List<Bill>> GetAllBills();
    }
}