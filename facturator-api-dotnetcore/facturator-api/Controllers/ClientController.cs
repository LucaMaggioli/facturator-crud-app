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


        [HttpGet("all")]
        public string GetClients()
        {
            // private ClientDataProvider _ClientDataProvider = new ClientDataProvider(_context);

            // List<Client> clients =  _ClientDataProvider.GetClients();
            List<Client> clients = new ClientDataProvider(_context).GetClients();

            return JsonSerializer.Serialize(clients);
        }

        [HttpGet("id")]
        public string GetClient(int id)
        {
            return "client - " + id.ToString();
        }

        [HttpPost("add")]
        public string AddClient([FromBody] ClientBody body)
        {
            new ClientDataProvider(_context).AddClient(body.Name, body.Address, body.Email);
            return "client registered";
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
