using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace facturator_api.Models
{
    public class Article
    {
        public Article(int id, string name, string photoUrl, decimal price, string description)
        {
            this.Id = id;
            this.Name = name;
            this.PhotoUrl = photoUrl;
            this.Price = price;
            this.Description = description;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public decimal Price { get; set; }
        public string Description{ get; set; }
    }
}
