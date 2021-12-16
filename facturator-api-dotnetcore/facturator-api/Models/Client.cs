using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace facturator_api.Models
{
    public class Client
    {
        public Client(int id, string name, string address, string email)
        {
            Id = id;
            Name = name;
            Address = address;
            this.Email = email;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

    }
}
