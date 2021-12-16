using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace facturator_api.Models
{
    public class Bill
    {
        public Bill(int id, DateTime date, float total, bool isValid)
        {
            Id = id;
            Date = date;
            Total = total;
            IsValid = isValid;
        }

        public Bill(int id, DateTime date, float total, bool isValid, List<Article> articles)
        {
            Id = id;
            Date = date;
            Total = total;
            IsValid = isValid;
            Articles = articles;
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public float Total { get; set; }
        public Boolean IsValid { get; set; }
        public List<Article> Articles { get; set; }
        
    }
}
