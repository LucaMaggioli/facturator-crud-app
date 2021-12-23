using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace facturator_api.Models
{
    public class Client
    {
        //public Client(int id, string name, string address, string email)
        public Client(string name, string address, string email)
        {
            Name = name;
            Address = address;
            Email = email;
            IsArchived = false;
        }

        public Client(string name, string address, string email, List<Bill> bills) :this(name, address, email)
        {
            Bills = bills;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public bool IsArchived { get; set; }
        public List<Bill> Bills { get; set; }

    }
}
