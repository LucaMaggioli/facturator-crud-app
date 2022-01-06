using facturator_api.Models;
using facturator_api.Models.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace facturator_api.DataProviders
{
    public class VendorDataProvider
    {
        private readonly FacturatorDbContext _facturatorDbContext;

        public VendorDataProvider(FacturatorDbContext context)
        {
            _facturatorDbContext = context;
        }

        public async Task<Vendor> GetVendorByIdAsync(int id)
        {
            Vendor vendor = await _facturatorDbContext.Vendors.FindAsync(id);
            return vendor;
        }

        public async Task<List<Client>> GetVendorClients(int id)
        {
            List<Client> clients = new List<Client>();
                Vendor vendor = await _facturatorDbContext.Vendors
                .Where(v => v.Id == id)
                .Include(vendor => vendor.Clients)
                .FirstOrDefaultAsync();

            vendor.Clients.ForEach(c =>
            {
                clients.Add(c);
            });

            return clients;
        }

        public async Task<Vendor> AddClientToVendor(Vendor vendor, Client client)
        {
            vendor.Clients.Add(client);
            await SaveChanges();

            return vendor;
        }

        internal async Task<Vendor> AddBillToVendor(Vendor vendor, Bill bill)
        {
            vendor.Bills.Add(bill);
            await SaveChanges();

            return vendor;
        }

        private async Task SaveChanges()
        {
            await _facturatorDbContext.SaveChangesAsync();
        }
    }
}
