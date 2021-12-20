using System.Net.Http;
using facturator_api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using System.Threading.Tasks;
using facturator_api.DataProviders;
using facturator_api.Models.Context;
using facturator_api.Models.Dtos;

namespace facturator_api.Controllers
{
    [Consumes("application/json")]
    [Route("api/[Controller]")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly FacturatorDbContext _context;
        public ClientController(FacturatorDbContext context){
            _context = context;
        }


        // Call this endpoint to get all the clients (TODO: call this endpoint to get all the clients for the current user)
        [HttpGet("all")]
        public async Task<List<ClientDto>> GetClients()
        {
            var clients = await new ClientDataProvider(_context).GetClientsAsync();

            return clients;
        }

        // Call this endpoint to get the client with the selected id
        [HttpGet("{id:int}")]
        public string GetClient(int id)
        {
            return "client - " + id.ToString();
        }

        // Call this endpoint to add a new client
        [HttpPost]
        public async Task<ClientDto> AddClient([FromBody] ClientBody body)
        {
            var client = await new ClientDataProvider(_context).AddClient(body.Name, body.Address, body.Email);
            return new ClientDto { Id = client.Id , Name = client.Name, Address = client.Address, Email = client.Email };
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ClientDto>> ArchiveClient(int id)
        {
            var deletedClient = await new ClientDataProvider(_context).ArchiveClient(id);
            return new ClientDto { Id = deletedClient.Id, Name = deletedClient.Name, Address = deletedClient.Address, Email = deletedClient.Email };
        }

        [HttpGet("archived")]
        public async Task<List<ClientDto>> GetArchivedClients()
        {
            var clients = await new ClientDataProvider(_context).GetArchivedClientsAsync();

            return clients;
        }

        public class ClientBody
        {
            public string Name { get; set; }
            public string Address { get; set; }
            public string Email { get; set; }
        }


        //Methods below should be in a service class
        //private List<string> _clientToJson(Client client)
        //{
        //    List<string> jsonClient = { "id":client.Id }
        //}

    }
}
