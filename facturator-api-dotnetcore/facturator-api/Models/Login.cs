using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace facturator_api.Models
{
    public class Login
    {
        public Login(string username, string password, Vendor vendor)
        {
            Username = username;
            Password = password;
            Vendor = vendor;
            //VendorId = vendorId;
        }
        
        //public Login(string username, string password, Vendor vendor) :this(username, password)
        //{
        //    Vendor = vendor;
        //}

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int VendorId { get; set; }
        [Required]
        public Vendor Vendor { get; set; }
    }
}
