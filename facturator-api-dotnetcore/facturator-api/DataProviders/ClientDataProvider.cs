using facturator_api.Models;
using facturator_api.Models.Context;
using facturator_api.Models.Dtos;
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


        public List<Client> GetClients()
        {
            List<Client> clients = new List<Client>();

            //  _facturatorDbContext.Clients.ForEach();
            _facturatorDbContext.Clients.ToList().ForEach(client =>{
                clients.Add(new Client(client.Id, client.Name, client.Address, client.Email));
            });

            return clients;
            // _facturatorDbContext.Clients.Select(client => new ClientDto{
            //     Id = client.Id,
            //     Name = client.Name,
            //     Address = client.Address,
            //     Email = client.Email,
            // });

            // try
            // {
            //     string[] lines = System.IO.File.ReadAllLines(this.path);
            //     //string[] lines = { "", "x" };
            //     foreach (string line in lines)
            //     {
            //         string[] columns = line.Split(',');
            //         int id = 0;
            //         int.TryParse(columns[0], out id);
            //         clients.Add(new Client(id, columns[1], columns[2], columns[3]));
            //     }
            // }
            // catch (FileNotFoundException exception)
            // {
            //     Console.WriteLine(exception);
            // }

        }

        public async Task<Client> AddClient(string name, string address, string email)
        {
            Client clientToAdd = new Client(0,name,address, email);

            var addedClient = await _facturatorDbContext.Clients.AddAsync(clientToAdd);
            await this.SaveChanges();

            return addedClient.Entity;
        }
        private async Task SaveChanges()
        {
            await _facturatorDbContext.SaveChangesAsync();
        }
    }
}
