using facturator_api.Models;
using facturator_api.Models.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace facturator_api.DataProviders
{
    public class VendorDataProvider : IVendorDataProvider
    {
        private readonly FacturatorDbContext _facturatorDbContext;

        public VendorDataProvider(FacturatorDbContext context)
        {
            _facturatorDbContext = context;
        }

        /// <summary>
        /// Get vendor by it's Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Vendor> GetVendorById(int id)
        {
            Vendor vendor = await _facturatorDbContext.Vendors.FindAsync(id);
            return vendor;
        }

        /// <summary>
        /// Update a vendor by it's Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="vendorUpdate"></param>
        /// <returns></returns>
        public async Task<Vendor> UpdateVendor(int id, Vendor vendorUpdate)
        {
            var vendor = await _facturatorDbContext.Vendors.FindAsync(id);

            if (vendor != null)
            {
                vendor.FirstName = vendorUpdate.FirstName;
                vendor.LastName = vendorUpdate.LastName;
                vendor.CompanyName = vendorUpdate.CompanyName;
                vendor.Address = vendorUpdate.Address;
                vendor.Email = vendorUpdate.Email;
                vendor.Iban = vendorUpdate.Iban;
                await SaveChanges();
            }

            return vendor;
        }

        /// <summary>
        /// Get Vendor With all his Articles and Clients by it's Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Vendor> GetFullVendorById(int id)
        {
            //Vendor vendor = await _facturatorDbContext.Vendors.FindAsync(id);
            Vendor vendor = await _facturatorDbContext.Vendors
            .Where(v => v.Id == id)
            .Include(vendor => vendor.Clients)
            //.Include(vendor => vendor.Bills)
            .Include(vendor => vendor.Articles)
            .FirstOrDefaultAsync();
            return vendor;
        }

        /// <summary>
        /// Get the clients of the Vendor by it's Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<Client>> GetNotArchivedClientsForVendor(int id)
        {
            Vendor vendor = await _facturatorDbContext.Vendors
            .Where(v => v.Id == id)
            .Include(vendor => vendor.Clients)
            .FirstOrDefaultAsync();

            List<Client> clients = new List<Client>();

            if (vendor.Clients != null)
            {
                vendor.Clients.ForEach(c =>
                {
                    if (!c.IsArchived)
                    {
                        clients.Add(c);
                    }
                });
            }

            return clients;
        }

        /// <summary>
        /// Add a client to a vendor
        /// </summary>
        /// <param name="vendor"></param>
        /// <param name="client"></param>
        /// <returns></returns>
        public async Task<Vendor> AddClientToVendor(Vendor vendor, Client client)
        {
            vendor.Clients.Add(client);
            await SaveChanges();

            return vendor;
        }

        /// <summary>
        /// Get the vendor articles
        /// </summary>
        /// <param name="vendor"></param>
        /// <returns></returns>
        public async Task<List<Client>> GetVendorArticles(Vendor vendor)
        {
            //is there another way to do this? for example pass as parameter a vendor that already have Clients
            vendor = await _facturatorDbContext.Vendors
            .Where(v => v.Id == vendor.Id)
            .Include(vendor => vendor.Clients)
            .FirstOrDefaultAsync();

            List<Client> clients = new List<Client>();

            if (vendor.Clients != null)
            {
                vendor.Clients.ForEach(c =>
                {
                    clients.Add(c);
                });
            }

            return clients;
        }

        /// <summary>
        /// Get bills for the vendor
        /// </summary>
        /// <param name="vendorId"></param>
        /// <returns></returns>
        public async Task<List<Bill>> GetBillsForVendor(int vendorId)
        {
            var bills = await _facturatorDbContext.Bills
                .Where(bill => bill.Vendor.Id == vendorId)
                .Select(bill => bill)
                .Include(bill => bill.Client).ToListAsync();
            return bills;
        }

        /// <summary>
        /// Add an article to a Vendor 
        /// </summary>
        /// <param name="vendor"></param>
        /// <param name="article"></param>
        /// <returns></returns>
        public async Task<Vendor> AddArticleToVendor(Vendor vendor, Article article)
        {
            vendor.Articles.Add(article);
            await SaveChanges();
            return vendor;
        }

        /// <summary>
        /// Add a Client and directly bind to a Vendor
        /// </summary>
        /// <param name="vendor"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="address"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<Client> AddClientToVendor(Vendor vendor, string firstName, string lastName, string address, string email)
        {
            var newClient = new Client(firstName, lastName, address, email);
            vendor.Clients.Add(newClient);
            await SaveChanges();
            return newClient;
        }

        private async Task SaveChanges()
        {
            await _facturatorDbContext.SaveChangesAsync();
        }
    }
}
