using facturator_api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace facturator_api.DataProviders
{
    public interface IVendorDataProvider
    {
        Task<Article> AddArticleToVendor(Vendor vendor, Article article);
        Task<Vendor> AddClientToVendor(Vendor vendor, Client client);
        Task<Client> AddClientToVendor(Vendor vendor, string firstName, string lastName, string address, string email);
        Task<List<Bill>> GetBillsForVendor(int vendorId);
        Task<Vendor> GetFullVendorById(int id);
        Task<List<Client>> GetVendorArticles(Vendor vendor);
        Task<Vendor> GetVendorById(int id);
        Task<List<Client>> GetNotArchivedClientsForVendor(int id);
        Task<Vendor> UpdateVendor(int id, Vendor vendorUpdate);
    }
}