using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace facturator_api.Models.Dtos
{
    public class BillDto
    {
        public BillDto() { }
        public BillDto(Bill bill)
        {
            Id = bill.Id;
            Date = bill.Date;
            Client = new ClientDto(bill.Client);
            Vendor = new VendorDto(bill.Vendor);
            Articles = bill.Articles.Select(a => new ArticleDto(a)).ToList();
            IsPayed = bill.IsPayed;
            Total = bill.Total;
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public bool IsPayed { get; set; }
        public ClientDto Client { get; set; }
        public VendorDto Vendor { get; set; }
        public List<ArticleDto> Articles { get; set; }

        public BillDto GetDtoFromBill(Bill bill)
        {

            BillDto billDto = new BillDto {
                Id = bill.Id,
                Date = bill.Date,
                Client = new ClientDto(bill.Client),
                Vendor = new VendorDto(bill.Vendor),
                Articles = bill.Articles.Select(a => new ArticleDto(a)).ToList(),
                IsPayed = bill.IsPayed,
                Total = bill.Total 
            };

            billDto.Articles = new List<ArticleDto>();
            bill.Articles.ForEach(billArticle =>
                {
                    billDto.Articles.Append(new ArticleDto(billArticle));
                }
            );

            return billDto;
        }
    }
}
