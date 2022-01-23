using Microsoft.VisualStudio.TestTools.UnitTesting;
using facturator_api.Controllers;
using facturator_api.Models.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using facturator_api.Models;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using facturator_api.DataProviders;
using facturator_api.Models.Dtos;
using facturator_api.Services;

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
        public async Task TestDataProviderGetArticle()
        {
            //Arrange
            await TestSetUp();
            var article = await Context.Articles.FirstAsync();

            //Act
            var articleGet = await new ArticleDataProvider(Context).GetArticleAsync(article.Id);

            //Assert
            Assert.AreEqual(article, articleGet);
        }

        [TestMethod]
        public async Task TestDataProviderGetAllArticles()
        {
            //Arrange
            await TestSetUp();
            var numberOfArticles = Context.Articles.Count();

            //Act
            var allArticlesGet = await new ArticleDataProvider(Context).GetArticlesAsync();

            //Assert
            Assert.AreEqual(numberOfArticles, allArticlesGet.Count());
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

        [TestMethod]
        public async Task TestDataProviderUpdateArticle()
        {
            //Arrange
            await TestSetUp();
            var article = await Context.Articles.FirstAsync();

            var initialName = article.Name;
            var initialPhotoUrl = article.PhotoUrl;
            var initialPrice= article.Price;
            var initialDescription= article.Description;

            //Act
            article = await new ArticleDataProvider(Context)
                .UpdateArticleById(article.Id, article.Name+ "modified", article.PhotoUrl+ "modified", article.Price+ 1, article.Description + "modified");

            //Assert
            Assert.AreNotEqual(initialName, article.Name);
            Assert.AreNotEqual(initialPhotoUrl, article.PhotoUrl);
            Assert.AreNotEqual(initialPrice, article.Price);
            Assert.AreNotEqual(initialDescription, article.Description);
        }

        [TestMethod]
        public async Task TestDataProviderGetClient()
        {
            //Arrange
            await TestSetUp();
            var client = Context.Clients.First();

            //Act
            var clientGet = await new ClientDataProvider(Context).GetClientById(client.Id);

            //Assert
            Assert.AreEqual(client, clientGet);
        }

        [TestMethod]
        public async Task TestDataProviderSetClientArchived()
        {
            //Arrange
            await TestSetUp();
            var expectedClient = Context.Clients.First();

            //Act
            expectedClient = await new ClientDataProvider(Context).SetArchived(expectedClient.Id, true);

            //Assert
            Assert.IsTrue(expectedClient.IsArchived);
        }

        [TestMethod]
        public async Task TestDataProviderGetArchivedClients()
        {
            //Arrange
            await TestSetUp();
            var numberOfArchivedClients = Context.Clients.Where(c=> c.IsArchived).Select(c=> c).ToList().Count();

            //Act
            var archivedClients = await new ClientDataProvider(Context).GetArchivedClientsAsync();

            //Assert
            Assert.AreEqual(numberOfArchivedClients, archivedClients.Count());
        }

        [TestMethod]
        public async Task TestDataProviderUpdateClient()
        {
            //Arrage
            await TestSetUp();
            var initialClient = Context.Clients.First();
            var initialFirstName = initialClient.FirstName;
            var initialLastName = initialClient.LastName;
            var initialAddress = initialClient.Address;
            var initialEmail= initialClient.Email;
            var clientUpdates = new ClientUpdateDto
            {
                FirstName = initialClient.FirstName + "modified",
                LastName = initialClient.LastName + "modified",
                Address = initialClient.Address + "modified",
                Email = initialClient.Email + "modified"
            };

            //Act
            var modifiedClient = await new ClientDataProvider(Context).Update(initialClient.Id, clientUpdates);

            //Assert
            Assert.AreNotEqual(initialFirstName, modifiedClient.FirstName);
            Assert.AreNotEqual(initialLastName, modifiedClient.LastName);
            Assert.AreNotEqual(initialAddress, modifiedClient.Address);
            Assert.AreNotEqual(initialEmail, modifiedClient.Email);
        }

        [TestMethod]
        public async Task EmailServiceWIthGoodEmailFormattingShouldReturnTrue()
        {
            //Arrange
            var emailService = new EmailService();
            var niceFormattedEmail = "nice.formatted@email.com";

            //Act
            var result = emailService.IsValidEmail(niceFormattedEmail);

            //Assert 
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task EmailServiceWIthBadEmailFormattingShouldReturnFalse()
        {
            //Arrange
            var emailService = new EmailService();
            var badFormatted1 = "should.be.bad.formatted@email.com.";
            var badFormatted2 = "should.be.bad.formatted@.email.com";
            var badFormatted3 = ".should.be.bad.formatted@email.com";

            //Act
            var expectedResult1 = emailService.IsValidEmail(badFormatted1);
            var expectedresult2 = emailService.IsValidEmail(badFormatted2);
            var expectedResult3 = emailService.IsValidEmail(badFormatted3);

            //Assert 
            Assert.IsFalse(expectedResult1);
            Assert.IsFalse(expectedresult2);
            Assert.IsFalse(expectedResult3);
        }

        //Test d' Integration
        //[TestMethod]
        //public async Task ControllerUpdateCLientForVendorWrongEmailAddress()
        //{
        //    //Arrange
        //    await TestSetUp();
        //    var vendor = Context.Vendors.First();

        //    //Act
        //    var clientToAdd = new ClientAddDto("fName", "lName", "address", "valid@email.com");
        //    var result = await new VendorController.AddClient(vendor.Id, clientToAdd);

        //    //Arrange
        //}

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
            context.Articles.Add(new Article("", "", (decimal)12.12, ""));

            context.Clients.Add(new Client("", "", "", ""));
            context.Clients.Add(new Client("", "", "", ""));
            context.Clients.Add(new Client("", "", "", ""));

            await context.SaveChangesAsync();

            return context;
        }

    }
}
