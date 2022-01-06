using facturator_api.Models;
using facturator_api.Models.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace facturator_api.DataProviders
{
    public class LoginDataProvider
    {
        private readonly FacturatorDbContext _facturatorDbContext;

        public LoginDataProvider(FacturatorDbContext context)
        {
            _facturatorDbContext = context;
        }

        public async Task<bool> UserNameExists(string username)
        {
            var loginFound = await _facturatorDbContext.Logins.Where(login => login.Username == username).FirstOrDefaultAsync();
            
            if (loginFound == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<Vendor> VendorLogin(string username, string password)
        {
            var login = await _facturatorDbContext.Logins
                .Where(l => l.Username == username && l.Password == password)
                .Include(l=> l.Vendor)
                .FirstOrDefaultAsync();

            if (login == null)
            {
                return null;
            }

            return login.Vendor;
        }

        public async Task<Vendor> VendorSingin(string username, string password, Vendor newVendor){

            var newLogin = new Login(username, password, newVendor);

            _facturatorDbContext.Logins.Add(newLogin);
            _facturatorDbContext.Vendors.Add(newVendor);
            await SaveChanges();

            return newVendor;
        }

        private async Task SaveChanges()
        {
            await _facturatorDbContext.SaveChangesAsync();
        }
    }
}
