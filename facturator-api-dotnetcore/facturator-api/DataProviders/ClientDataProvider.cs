using System.Net.Http;
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
    public class ClientDataProvider : IClientDataProvider
    {
        private readonly FacturatorDbContext _facturatorDbContext;

        public ClientDataProvider(FacturatorDbContext context)
        {
            _facturatorDbContext = context;
        }

        public ClientDataProvider()
        {
        }

        /// <summary>
        /// Return a specific client by a given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Client> GetClientById(int id)
        {
            // TOASK quelle est la difference entre "return client" et Return "client.Entity"
            var client = await _facturatorDbContext.Clients.FindAsync(id);
            return client;
        }

        /// <summary>
        /// Return all clients
        /// </summary>
        /// <returns></returns>
        public async Task<List<Client>> GetClientsAsync()
        {
            var clients = await _facturatorDbContext.Clients
                .Where(c => !c.IsArchived)
                .Select(client => client)
                //new ClientDto { Id = client.Id , Name = client.Name, Address = client.Address, Email = client.Email })
                .ToListAsync();

            return clients;
        }

        /// <summary>
        /// Add a new client
        /// </summary>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<Client> Add(string name, string address, string email)
        {
            Client clientToAdd = new Client(name, address, email);

            var addedClient = await _facturatorDbContext.Clients.AddAsync(clientToAdd);
            await SaveChanges();

            return addedClient.Entity;
        }

        /// <summary>
        /// Update an existing client by it's Id
        /// </summary>
        /// <param name="clientToUpdate"></param>
        /// <returns></returns>
        public async Task<Client> Update(int id,  ClientDto clientToUpdate)
        {
            var client = await _facturatorDbContext.Clients.FindAsync(id);

            if (client != null)
            {
                client.Name = clientToUpdate.Name;
                client.Address = clientToUpdate.Address;
                client.Email = clientToUpdate.Email;
                await SaveChanges();
            }
            return client;
        }

        /// <summary>
        /// Set the IsArchived property of a Client by a given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Client> SetArchived(int id, bool isArchived)
        {
            var client = await _facturatorDbContext.Clients.FirstOrDefaultAsync(c => c.Id == id);
            if (client != null)
            {
                client.IsArchived = isArchived;
                await SaveChanges();
            }
            return client;
        }

        /// <summary>
        /// Get all the clients that have IsArchived property set to True
        /// </summary>
        /// <returns></returns>
        public async Task<List<ClientDto>> GetArchivedClientsAsync()
        {
            var archivedClients = await _facturatorDbContext.Clients
                .Where(c => c.IsArchived)
                .Select(client => new ClientDto { Id = client.Id, Name = client.Name, Address = client.Address, Email = client.Email })
                .ToListAsync();
            return archivedClients;
        }

        private async Task SaveChanges()
        {
            await _facturatorDbContext.SaveChangesAsync();
        }
    }
}
