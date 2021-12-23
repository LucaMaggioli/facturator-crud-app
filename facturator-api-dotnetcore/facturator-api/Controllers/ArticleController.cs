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

        [HttpGet("all")]
        public async Task<List<Article>> getArticles()
        {
            var articles = await _articleDataProvider.GetArticlesAsync();

            return articles;
        }

        [HttpPost]
        public string AddArticle([FromBody] ArticleBody body)
        {
            this._articleDataProvider.AddArticle(body.Name, body.PhotoUrl, body.Price, body.Description);
            return "article registered";
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
