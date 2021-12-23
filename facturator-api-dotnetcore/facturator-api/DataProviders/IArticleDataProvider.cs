using facturator_api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace facturator_api.DataProviders
{
    public interface IArticleDataProvider
    {
        Task<ActionResult<Article>> AddArticle(string name, string photoUrl, decimal price, string description);
        Task<List<Article>> GetArticlesAsync();
    }
}