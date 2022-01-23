﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace facturator_api.Models
{
    public class Client : User
    {
        public Client(int id)
            :base(id)
        {
        }

        public Client(string firstName, string lastName, string address, string email) 
            : base(firstName, lastName, address, email)
        {
            IsArchived = false;
            ClientUniqueCode = "generate here a unique code to let clients login into their Client Page to see their Bills";
        }

        public Client(string firstName, string lastName, string address, string email, int id)
            : base(firstName, lastName, address, email)
        {
            Id = id;
        }

        public string ClientUniqueCode { get; set; }
        public bool IsArchived { get; set; }

    }
}
