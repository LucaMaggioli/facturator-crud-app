using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace facturator_api.Models.Dtos
{
    public class VendorDto
    {
        public VendorDto(){}
        public VendorDto(Vendor vendor)
        {
            Id = vendor.Id;
            FirstName = vendor.FirstName;
            LastName = vendor.LastName;
            CompanyName = vendor.CompanyName;
            Address = vendor.Address;
            Email = vendor.Email;
            Iban = vendor.Iban;
            Clients = new List<ClientDto>();
            vendor.Clients.ForEach(client =>
            {
                var clientDto = new ClientDto(client);
                Clients.Add(clientDto);
            });
            //Bills = new List<BillDto>();
            //vendor.Bills.ForEach(bill =>
            //{
            //    var billDto = new BillDto(bill);
            //    Bills.Add(billDto);
            //});
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Iban { get; set; }
        public List<ClientDto> Clients { get; set; }
        public List<BillDto> Bills { get; set; }
    }
}
