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
                .Where(article => !article.IsArchived)
                .Select(article => article)
                .ToListAsync();

            return articles;
        }

        public async Task<Article> GetArticleAsync(int id)
        {
            var article = await _facturatorDbContext.Articles.FindAsync(id);

            return article;
        }

        public async Task<Article> AddArticle(string name, string photoUrl, decimal price, string description)
        {
            var articleToAdd = new Article(name, photoUrl, price, description);
            _facturatorDbContext.Articles.Add(articleToAdd);
            await SaveChanges();

            return articleToAdd;
        }

        /// <summary>
        /// Update an existing article by it's Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="photoUrl"></param>
        /// <param name="price"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public async Task<Article> UpdateArticle(int id, string name, string photoUrl, decimal price, string description)
        {
            var article = await _facturatorDbContext.Articles.FindAsync(id);

            if (article != null)
            {
                article.Name = name;
                article.PhotoUrl = photoUrl;
                article.Price = price;
                article.Description = description;
                await SaveChanges();
            }

            return article;
        }

        //TOASK better DeleteArticle(int id) or DeleteArticle(Article articleToDelete)???
        //this will result into a controller modification too:
        //controller should use _articleDataProvider.GetArticleAsync(id) 
        //and then the found article is passed thruough this method ->
        //in controller call: _articleDataProvider.DeleteArticle(Article article);
        public async Task<Article> DeleteArticleById(int id)
        {
            var article = await _facturatorDbContext.Articles.FindAsync(id);
            article.IsArchived = true;

            await SaveChanges();

            return article;
        }
        //Or better like this ? 
        /*
        public async Task<Article> DeleteArticle(Article articleToDelete)
        {
            articleToDelete.IsArchived = true;
            await SaveChanges();

            return articleToDelete;
        }*/


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

        public Task<Article> DeleteArticleById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Article>> GetArticlesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Article> UpdateArticle(int id, string name, string photoUrl, decimal price, string description)
        {
            throw new NotImplementedException();
        }

        public List<Article> getMockArticles()
        {
            return new List<Article> { new Article("", "", 1, "") };
        }

        Task<Article> IArticleDataProvider.AddArticle(string name, string photoUrl, decimal price, string description)
        {
            throw new NotImplementedException();
        }

        public Task<Article> GetArticleAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
