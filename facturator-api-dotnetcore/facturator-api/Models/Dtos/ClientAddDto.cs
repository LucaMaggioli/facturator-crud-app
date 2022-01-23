using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace facturator_api.Models.Dtos
{
    public class ClientAddDto
    {
        public ClientAddDto(string firstName, string lastName, string address, string email)
        {
            this.FirstName = firstName;
            this.LastName= lastName;
            this.Address= address;
            this.Email = email;
        }

        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string Address {get;set;}
        public string Email {get;set; }
    }
}
