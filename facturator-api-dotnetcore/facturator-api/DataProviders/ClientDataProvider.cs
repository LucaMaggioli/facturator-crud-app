using facturator_api.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace facturator_api.DataProviders
{
    public class ClientDataProvider
    {

        private string path = @"C:\Users\maggioli\Desktop\Apprentissage\EPSIC-3\i326\facturator\facturator-api-dotnetcore\facturator-api\Data\Clients.csv";


        public List<Client> GetClients()
        {
            List<Client> clients = new List<Client>();

            try
            {
                string[] lines = System.IO.File.ReadAllLines(this.path);
                //string[] lines = { "", "x" };
                foreach (string line in lines)
                {
                    string[] columns = line.Split(',');
                    int id = 0;
                    int.TryParse(columns[0], out id);
                    clients.Add(new Client(id, columns[1], columns[2], columns[3]));
                }
            }
            catch (FileNotFoundException exception)
            {
                Console.WriteLine(exception);
            }

            return clients;
        }

        public async void AddClient(string name, string address, string email)
        {
            try
            {
                //get Id for new client
                string[] lines = System.IO.File.ReadAllLines(this.path);
                int id = lines.Length;

                //add new Client to file
                using StreamWriter file = new StreamWriter(this.path, append: true);
                file.WriteLine( id + ", " + name + ", " + address + ", " + email + ",");
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
