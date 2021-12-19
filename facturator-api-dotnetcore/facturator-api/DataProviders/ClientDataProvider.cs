using facturator_api.Models;
using facturator_api.Models.Context;
using facturator_api.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace facturator_api.DataProviders
{
    public class ClientDataProvider
    {
        private readonly FacturatorDbContext _facturatorDbContext;

        public ClientDataProvider(FacturatorDbContext context){
            _facturatorDbContext = context;
        }

        public ClientDataProvider()
        {
        }

        private string path = @"C:\Users\maggioli\Desktop\Apprentissage\EPSIC-3\i326\facturator\facturator-api-dotnetcore\facturator-api\Data\Clients.csv";

        /// <summary>
        /// Return all clients
        /// </summary>
        /// <returns></returns>
        public async Task<List<ClientDto>> GetClientsAsync()
        {
            var clients = await _facturatorDbContext.Clients.Select(client =>
                new ClientDto { Name = client.Name, Address = client.Address, Email = client.Email }
            ).ToListAsync();

            return clients;
        }

        public async Task<Client> AddClient(string name, string address, string email)
        {
            Client clientToAdd = new Client(name,address, email);

            var addedClient = await _facturatorDbContext.Clients.AddAsync(clientToAdd);
            await SaveChanges();

            return addedClient.Entity;
        }
        private async Task SaveChanges()
        {
            await _facturatorDbContext.SaveChangesAsync();
        }
    }
}
