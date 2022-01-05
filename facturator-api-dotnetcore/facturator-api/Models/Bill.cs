using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace facturator_api.Models
{
    public class Bill
    {
        public Bill(int id, DateTime date, bool isPayed)
        {
            Id = id;
            Date = date;
            Total = 0;
            IsPayed = isPayed;
        }

        public Bill(int id, DateTime date, bool isPayed, List<Article> articles)
        {
            articles.ForEach(article => { Total += article.Price; });
            Id = id;
            Date = date;
            IsPayed = isPayed;
            Articles = articles;
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public bool IsPayed { get; set; }
        public List<Article> Articles { get; set; }
        
    }
}
