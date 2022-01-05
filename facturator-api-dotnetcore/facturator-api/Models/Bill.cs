using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace facturator_api.Models
{
    public class Bill
    {
        public Bill(DateTime date, bool isPayed, Client client, Vendor vendor, List<Article> articles)
        {
            Date = date;
            Total = 0;
            IsPayed = isPayed;
            Client = client;
            Vendor = vendor;
            articles.ForEach(article => { Total += article.Price; });
            Articles = articles;
        }

        //public Bill(DateTime date, bool isPayed, Client client, Vendor vendor, List<Article> articles) : this(date, isPayed, client, vendor)
        //{
        //    articles.ForEach(article => { Total += article.Price; });
        //    Articles = articles;
        //}

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public bool IsPayed { get; set; }
        [Required]
        public Client Client{ get; set; }
        [Required]
        public Vendor Vendor { get; set; }
        [Required]
        public List<Article> Articles { get; set; }
        
    }
}
