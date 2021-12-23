using facturator_api.Models;
using facturator_api.Models.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace facturator_api.DataProviders
{
    public class ArticleDataProvider : IArticleDataProvider
    {

        private readonly FacturatorDbContext _facturatorDbContext;

        public ArticleDataProvider(FacturatorDbContext context)
        {
            _facturatorDbContext = context;
        }

        public async Task<List<Article>> GetArticlesAsync()
        {
            var articles = await _facturatorDbContext.Articles
                .Select(article => article)
                .ToListAsync();

            return articles;
        }

        public async Task<ActionResult<Article>> AddArticle(string name, string photoUrl, decimal price, string description)
        {
            var articleToAdd = new Article(name, photoUrl, price, description);
            _facturatorDbContext.Articles.Add(articleToAdd);
            await SaveChanges();

            return articleToAdd;
        }

        private async Task SaveChanges()
        {
            await _facturatorDbContext.SaveChangesAsync();
        }
    }



    public class ArticleDataProviderMock : IArticleDataProvider
    {
        public void AddArticle(string name, string photoUrl, string price, string description)
        {
            
        }

        public Task<Article> AddArticle(string name, string photoUrl, decimal price, string description)
        {
            throw new NotImplementedException();
        }

        public List<Article> getArticles()
        {
            return new List<Article> { new Article("", "", 1, "")};
        }

        public Task<List<Article>> GetArticlesAsync()
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Article>> IArticleDataProvider.AddArticle(string name, string photoUrl, decimal price, string description)
        {
            throw new NotImplementedException();
        }
    }
}
