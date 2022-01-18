using Microsoft.VisualStudio.TestTools.UnitTesting;
using facturator_api.Controllers;
using facturator_api.Models.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using facturator_api.Models;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using facturator_api.DataProviders;

namespace Test_Facturator
{
    [TestClass]
    public class TestFacturatorApi
    {

        protected FacturatorDbContext Context { get; private set; }

        [TestInitialize]
        public async Task TestSetUp()
        {
            Context = InMemoryContext();
            Context = await PopulateDbData(Context);
        }

        [TestMethod]
        public async Task TestArticleDataProviderAddArticle()
        {
            //Arrange
            await TestSetUp();
            var initialArticlesCount = Context.Articles.Count();

            //Act
            var newArticle = new Article("chair", "https://picsum.photos/200", (decimal)12.50, "A little description", 7);
            await new ArticleDataProvider(Context).AddArticle(newArticle.Name, newArticle.PhotoUrl, newArticle.Price, newArticle.Description);

            //Assert
            Assert.AreEqual(Context.Articles.Count(), initialArticlesCount + 1);
        }

        [TestMethod]
        public async Task TestDataProviderDeleteArticle()
        {
            //Arrange
            await TestSetUp();
            var article = Context.Articles.First();
            article.IsArchived = false;
            await Context.SaveChangesAsync();

            //Act
            article = await new ArticleDataProvider(Context).DeleteArticleById(article.Id);
            
            //Assert
            Assert.IsTrue(article.IsArchived);
        }

        private FacturatorDbContext InMemoryContext()
        {
            // SEE: https://docs.microsoft.com/en-us/ef/core/miscellaneous/testing/sqlite
            var connection = new SqliteConnection("Data Source=:memory:");
            var options = new DbContextOptionsBuilder<FacturatorDbContext>()
                .UseSqlite(connection)
                .Options;
            connection.Open();

            // create the schema
            using (var context = new FacturatorDbContext(options))
            {
                context.Database.EnsureCreated();
            }

            return new FacturatorDbContext(options);

        }

        private async Task<FacturatorDbContext> PopulateDbData(FacturatorDbContext context)
        {
            context.Articles.Add(new Article("", "", (decimal)11.11, ""));
            context.Articles.Add(new Article("", "", (decimal)11.11, ""));
            //context.Articles.Add(new Article("", "", (decimal)11.11, "", 0));
            //context.Articles.Add(new Article("", "", (decimal)12.12, "", 1));
            //context.Articles.Add(new Article("", "", (decimal)13.13, "", 2));
            //context.Articles.Add(new Article("", "", (decimal)14.14, "", 3));
        
            //context.Clients.Add(new Client("", "", "", "", 0));
            //context.Clients.Add(new Client("", "", "", "", 1));
            //context.Clients.Add(new Client("", "", "", "", 2));
            //context.Clients.Add(new Client("", "", "", "", 3));

            await context.SaveChangesAsync();

            return context;
        }

    }
}
