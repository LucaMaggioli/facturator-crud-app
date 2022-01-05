using facturator_api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace facturator_api.DataProviders
{
    public interface IArticleDataProvider
    {
        Task<Article> AddArticle(string name, string photoUrl, decimal price, string description);
        Task<Article> DeleteArticle(int id);
        Task<Article> GetArticleAsync(int id);
        Task<List<Article>> GetArticlesAsync();
        Task<Article> UpdateArticle(int id, string name, string photoUrl, decimal price, string description);
    }
}