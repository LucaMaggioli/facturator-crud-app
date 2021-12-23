using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace facturator_api.Models
{
    public class Article
    {
        public Article(string name, string photoUrl, decimal price, string description)
        {
            this.Name = name;
            this.PhotoUrl = photoUrl;
            this.Price = price;
            this.Description = description;
        }
        public Article(string name, string photoUrl, decimal price, string description, int id) : this(name, photoUrl, price, description)
        {
            this.Id = id;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public decimal Price { get; set; }
        public string Description{ get; set; }
    }
}
