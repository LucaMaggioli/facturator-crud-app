using facturator_api.Models;
using facturator_api.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace facturator_api.DataProviders
{
    interface IClientDataProvider
    {
        /// <summary>
        /// Get a client by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Client> GetClientById(int id);

        /// <summary>
        /// Get all Clients Async
        /// </summary>
        /// <returns></returns>
        Task<List<Client>> GetClientsAsync();

        /// <summary>
        /// Add a client
        /// </summary>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<Client> Add(string name, string address, string email);

        /// <summary>
        /// Get the clients with property IsArchived = true
        /// </summary>
        /// <returns></returns>
        Task<List<ClientDto>> GetArchivedClientsAsync();

        /// <summary>
        /// Set the property IsArchived to a passed value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isArchived"></param>
        /// <returns></returns>
        Task<Client> SetArchived(int id, bool isArchived);

        /// <summary>
        /// Update the Client
        /// </summary>
        /// <param name="clientToUpdate"></param>
        /// <returns></returns>
        Task<Client> Update(int id, ClientDto clientToUpdate);
    }
}
