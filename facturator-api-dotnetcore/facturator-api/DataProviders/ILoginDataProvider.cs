using facturator_api.Models;
using System.Threading.Tasks;

namespace facturator_api.DataProviders
{
    public interface ILoginDataProvider
    {
        Task<bool> UserNameExists(string username);
        Task<Vendor> VendorLogin(string username, string password);
        Task<Vendor> VendorSingin(string username, string password, Vendor newVendor);
    }
}