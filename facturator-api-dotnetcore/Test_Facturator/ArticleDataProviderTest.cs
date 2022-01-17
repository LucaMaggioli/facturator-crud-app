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
    public class ArticleDataProviderTest
    {

        protected DbContextOptions<FacturatorDbContext> Options { get; private set; }
        protected FacturatorDbContext Context { get; private set; }

        [TestInitialize]
        public void TestSetUp()
        {
            var options = new DbContextOptionsBuilder<FacturatorDbContext>().UseSqlite(@"Data Source=./Facturator.db;").Options;

            Options = options;

            Context = InMemoryContext();
        }

        [TestMethod]
        public async Task TestAddArticle()
        {
            TestSetUp();

            var initialArticlesCount = Context.Articles.Count();

            var newArticle = new Article("chair", "https://picsum.photos/200", (decimal)12.50, "A little description", 1);
            await new ArticleDataProvider(Context).AddArticle(newArticle.Name, newArticle.PhotoUrl, newArticle.Price, newArticle.Description);

            var finalArticlesCount = Context.Articles.Count();

            Assert.AreEqual(initialArticlesCount + 1 , finalArticlesCount);
        }

        public static FacturatorDbContext InMemoryContext()
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

    }
}
