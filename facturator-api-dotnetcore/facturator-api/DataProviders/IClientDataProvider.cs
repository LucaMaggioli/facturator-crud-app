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
        Task<List<ClientDto>> GetClientsAsync();
    }
}
