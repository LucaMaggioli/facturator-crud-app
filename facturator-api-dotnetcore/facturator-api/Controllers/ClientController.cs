﻿using System.Net.Http;
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
using facturator_api.Controllers.Bodys;

namespace facturator_api.Controllers
{
    [Consumes("application/json")]
    [Route("api/[Controller]")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly IClientDataProvider _clientDataProvider;

        public ClientController(IClientDataProvider clientDataProvider)
        {
            _clientDataProvider = clientDataProvider;
        }


        // Call this endpoint to get all the clients (TODO: call this endpoint to get all the clients for the current user)
        [HttpGet("all")]
        public async Task<List<ClientDto>> GetClients()
        {
            var clients = await _clientDataProvider.GetClientsAsync();
            
            var clientsDto = clients
                .Select(client => new ClientDto { Id = client.Id, FirstName = client.FirstName, LastName = client.LastName, Address = client.Address, Email = client.Email })
                .ToList();

            return clientsDto;
        }

        // Call this endpoint to get the client with the selected id
        [HttpGet("{id:int}")]
        public async Task<ClientDto> GetClient(int id)
        {
            var client = await _clientDataProvider.GetClientById(id);

            return new ClientDto { Id = client.Id, FirstName = client.FirstName, LastName = client.LastName, Address = client.Address, Email = client.Email };
        }

        // Call this endpoint to add a new client
        [HttpPost]
        public async Task<ClientDto> AddClient([FromBody] ClientBody body)
        {
            var client = await _clientDataProvider.Add(body.FirstName, body.LastName, body.Address, body.Email);

            return new ClientDto { Id = client.Id, FirstName = client.FirstName, LastName = client.LastName, Address = client.Address, Email = client.Email };
        }

        // Call this endpoint to Update an existing client
        [HttpPatch("{id:int}")]
        public async Task<IActionResult> UpdateClient(int id, [FromBody] ClientBody body)
        {
            if (!this.IsValidEmail(body.Email))
            {
                return StatusCode(422, "Email provided is not right format");
            }
            //var updatedClientDto = new ClientDto { Id = body.Id, FirstName = body.FirstName, LastName = body.LastName, Address = body.Address, Email = body.Email };
            var updatedClient = new ClientUpdateDto { FirstName = body.FirstName, LastName = body.LastName, Address = body.Address, Email = body.Email };
            var client = await _clientDataProvider.Update(id, updatedClient);
            if(client == null)
            {
                return StatusCode(404, "Client not found with given Id");
            }
            //If is null should return an error code
            return Ok(new ClientDto { Id = client.Id, FirstName = client.FirstName, LastName = client.LastName, Address = client.Address, Email = client.Email });
        }

        // Call this endpoint to Archive a client by it's Id
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ClientDto>> ArchiveClient(int id)
        {
            var deletedClient = await _clientDataProvider.SetArchived(id, true);

            if (deletedClient != null){
                return new ClientDto { Id = deletedClient.Id, FirstName = deletedClient.FirstName, LastName = deletedClient.LastName, Address = deletedClient.Address, Email = deletedClient.Email };
            }
            else
            {
                return NotFound("Client to Archive not found");
            }
        }

        // Call this enpoint to get all the Archived clients
        [HttpGet("archived")]
        public async Task<List<ClientDto>> GetArchivedClients()
        {
            var clients = await _clientDataProvider.GetArchivedClientsAsync();
            return clients;
        }



        /// <summary>
        /// private method to check if the email is in a valid format, it's only used in this controller that's why I didn't created an Utility Class yet 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        private bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false; // suggested by @TK-421
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

    }
}
