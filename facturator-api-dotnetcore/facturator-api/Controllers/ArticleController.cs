using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using facturator_api.DataProviders;
using facturator_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace facturator_api.Controllers
{
    //[Consumes("application/json")]
    [Route("api/[Controller]")]
    [ApiController]
    public class ArticleController : Controller
    {
        private readonly IArticleDataProvider _articleDataProvider;

        public ArticleController(IArticleDataProvider articleDataProvider)
        {
            _articleDataProvider = articleDataProvider;
        }

        // Call this enpoint to get the list of all available articles 
        [HttpGet]
        public async Task<List<Article>> getArticles()
        {
            var articles = await _articleDataProvider.GetArticlesAsync();

            return articles;
        }

        // Call this enpoint to get the list of all available articles 
        [HttpGet("{id:int}")]
        public async Task<Article> getArticle(int id)
        {
            var articles = await _articleDataProvider.GetArticleAsync(id);

            return articles;
        }

        // Call this enpoint to add an article
        [HttpPost]
        public string AddArticle([FromBody] ArticleBody body)
        {
            var addedArticle = this._articleDataProvider.AddArticle(body.Name, body.PhotoUrl, body.Price, body.Description);
            Console.WriteLine("new article added");
            Console.WriteLine(addedArticle);
            return "article registered";
        }

        // Call this enpoint to update an article
        [HttpPatch("{id:int}")]
        public Task<Article> UpdateArticle(int id, [FromBody] ArticleBody body)
        {
            //var article = this._articleDataProvider.GetArticleAsync(id);

            var updatedArticle = this._articleDataProvider.UpdateArticleById(id, body.Name, body.PhotoUrl, body.Price, body.Description);
            return updatedArticle;
        }

        // Call this endpoint to Delete an article
        [HttpDelete("{id:int}")]
        public Task<Article> DeleteArticle(int id)
        {
            var deletedArticle = _articleDataProvider.DeleteArticleById(id);
            
            return deletedArticle;
        }

        public class ArticleBody
        {
            public string Name { get; set; }
            public string PhotoUrl { get; set; }
            public decimal Price { get; set; }
            public string Description { get; set; }
        }
    }
}
