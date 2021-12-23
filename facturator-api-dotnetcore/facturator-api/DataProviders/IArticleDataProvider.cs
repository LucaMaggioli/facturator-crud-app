using facturator_api.Models;
using System.Collections.Generic;

namespace facturator_api.DataProviders
{
    public interface IArticleDataProvider
    {
        void AddArticle(string name, string photoUrl, string price, string description);
        List<Article> getArticles();
    }
}