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

        private ArticleDataProvider _articleDataProvider = new ArticleDataProvider();

        [HttpGet]
        public string getArticles()
        {
            List<Article> articles = this._articleDataProvider.getArticles();

            return JsonSerializer.Serialize(articles);
        }

        [HttpPost]
        public string AddClient([FromBody] ArticleBody body)
        {
            jjthis._articleDataProvider.AddArticle(body.Name, body.PhotoUrl, body.Price, body.Description);
            return "article registered";
        }

        public class ArticleBody
        {
            public string Name { get; set; }
            public string PhotoUrl { get; set; }
            public string Price { get; set; }
            public string Description { get; set; }
        }
    }
}
