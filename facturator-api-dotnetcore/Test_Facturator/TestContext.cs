using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Facturator
{
    class TestContext
    {
    }
    //public static MyDbContext InMemoryContext()
    //{
    //    // SEE: https://docs.microsoft.com/en-us/ef/core/miscellaneous/testing/sqlite
    //    var connection = new SqliteConnection("Data Source=:memory:");
    //    var options = new DbContextOptionsBuilder<MyDbContext>()
    //        .UseSqlite(connection)
    //        .Options;
    //    connection.Open();

    //    // create the schema
    //    using (var context = new MyDbContext(options))
    //    {
    //        context.Database.EnsureCreated();
    //    }

    //    return new MyDbContext(options);

    //}
}
