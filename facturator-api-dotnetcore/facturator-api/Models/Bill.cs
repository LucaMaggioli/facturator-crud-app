using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace facturator_api.Models
{
    public class Bill
    {
        public Bill(DateTime date, bool isPayed)
        {
            Date = date;
            Total = 0;
            IsPayed = isPayed;
            Articles = new List<Article>();

        }
        public Bill(DateTime date, bool isPayed, List<Article> articles, Client client, Vendor vendor) :this(date, isPayed)
        {
            articles.ForEach(article => { Total += article.Price; });
            Articles = articles;
            Client = client;
            Vendor = vendor;
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public bool IsPayed { get; set; }
        public Client Client { get; set; }
        public Vendor Vendor { get; set; }
        public List<Article> Articles { get; set; }
        public bool IsArchived { get; set; }
    }
}
