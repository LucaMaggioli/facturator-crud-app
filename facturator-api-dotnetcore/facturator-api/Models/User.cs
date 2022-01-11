using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace facturator_api.Models
{
    public class User
    {
        public User(string firstName, string lastName, string address, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Email = email;
            //Bills = new List<Bill>();
        }

        //public User(string firstName, string lastName, string address, string email, List<Bill> bills) : this(firstName, lastName, address, email)
        //{
        //    Bills = bills;
        //}

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        //public List<Bill> Bills { get; set; }
    }
}
