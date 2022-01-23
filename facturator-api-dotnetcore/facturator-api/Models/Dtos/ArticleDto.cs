using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace facturator_api.Models.Dtos
{
    public class ArticleDto
    {
        public ArticleDto() { }
        public ArticleDto(Article article)
        {
            Id = article.Id;
            Name = article.Name;
            PhotoUrl = article.PhotoUrl;
            Description = article.Description;
            Price = article.Price;
            IsArchived = article.IsArchived;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public bool IsArchived { get; set; }
    }
}
