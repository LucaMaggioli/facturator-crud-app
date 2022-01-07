using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace facturator_api.Models.Dtos
{
    public class ClientDto
    {
        public ClientDto() { }
        public ClientDto(Client client)
        {
            Id = client.Id;
            FirstName = client.FirstName;
            LastName= client.LastName;
            Address = client.Address;
            Email = client.Email;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public void ClientDtoFromClient(Client client)
        {
            Id = client.Id;
            FirstName = client.FirstName;
            LastName = client.LastName;
            Address = client.Address;
            Email = client.Email;
        }
    }
}
