using facturator_api.Models;
using System.Threading.Tasks;

namespace facturator_api.DataProviders
{
    public interface IBillDataProvider
    {
        /// <summary>
        /// Get a Bill by it's Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Bill> GetBillById(int id);
    }
}