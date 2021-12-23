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
        // TOASK better /client/all or /clients  -> /client/all/archived or /clients/archived
        [HttpGet("all")]
        public async Task<List<ClientDto>> GetClients()
        {
            var clients = await new ClientDataProvider(_context).GetClientsAsync();
            
            var clientsDto = clients
                .Select(client => new ClientDto { Id = client.Id, Name = client.Name, Address = client.Address, Email = client.Email })
                .ToList();

            return clientsDto;
        }

        // Call this endpoint to get the client with the selected id
        [HttpGet("{id:int}")]
        public async Task<ClientDto> GetClient(int id)
        {
            var client = await new ClientDataProvider(_context).GetClientById(id);

            return new ClientDto { Id = client.Id, Name = client.Name, Address = client.Address, Email = client.Email };
        }

        // Call this endpoint to add a new client
        [HttpPost]
        public async Task<ClientDto> AddClient([FromBody] ClientBody body)
        {
            var client = await new ClientDataProvider(_context).Add(body.Name, body.Address, body.Email);

            return new ClientDto { Id = client.Id , Name = client.Name, Address = client.Address, Email = client.Email };
        }

        // Call this endpoint to Update an existing client
        [HttpPatch]
        public async Task<ClientDto> UpdateClient([FromBody] ClientBody body)
        {
            var client = await new ClientDataProvider(_context).Update(new ClientDto { Id = body.Id, Name = body.Name, Address = body.Address, Email = body.Email });
            //If is null should return an error code
            return new ClientDto { Id = client.Id, Name = client.Name, Address = client.Address, Email = client.Email };
        }

        // Call this endpoint to Archive a client by it's Id
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ClientDto>> ArchiveClient(int id)
        {
            var deletedClient = await new ClientDataProvider(_context).SetArchived(id, true);

            if (deletedClient != null){
                return new ClientDto { Id = deletedClient.Id, Name = deletedClient.Name, Address = deletedClient.Address, Email = deletedClient.Email };
            }
            else
            {
                return NotFound("Client to Archive not found");
            }
        }

        // Call this enpoint to get all the Archived clients
        [HttpGet("all/archived")]
        public async Task<List<ClientDto>> GetArchivedClients()
        {
            var clients = await new ClientDataProvider(_context).GetArchivedClientsAsync();
            return clients;
        }

        public class ClientBody
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public string Email { get; set; }
        }
    }
}
