using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace facturator_api.Models
{
    public class Vendor : User
    {
        public Vendor(string firstName, string lastName, string companyName, string address, string email, string iban) :base(firstName, lastName, address, email)
        {
            CompanyName = companyName;
            Iban = iban;
            Clients = new List<Client>();
            Articles = new List<Article>();
        }

        public string CompanyName { get; set; }
        public string Iban { get; set; }
        public List<Client> Clients { get; set; }
        public List<Article> Articles { get; set; }
    }
}
