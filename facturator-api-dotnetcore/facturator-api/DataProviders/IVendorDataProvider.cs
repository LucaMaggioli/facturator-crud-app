using facturator_api.Models;
using facturator_api.Models.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace facturator_api.DataProviders
{
    public interface IVendorDataProvider
    {
        Task<Article> AddArticleToVendor(Vendor vendor, Article article);
        Task<Vendor> AddClientToVendor(Vendor vendor, Client client);
        Task<Client> AddClientToVendor(Vendor vendor, ClientAddDto client);
        Task<List<Bill>> GetBillsForVendor(int vendorId);
        Task<Vendor> GetFullVendorById(int id);
        Task<List<Bill>> GetNotArchivedBills(int vendorId);
        Task<List<Client>> GetNotArchivedClientsForVendor(int id);
        Task<List<Client>> GetVendorArticles(Vendor vendor);
        Task<Vendor> GetVendorById(int id);
        Task<Vendor> UpdateVendor(int id, Vendor vendorUpdate);
    }
}