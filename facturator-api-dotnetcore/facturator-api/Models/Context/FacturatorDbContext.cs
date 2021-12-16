using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facturator_api.Models.Context
{
    public class FacturatorDbContext : DbContext
    {

        public FacturatorDbContext(DbContextOptions<FacturatorDbContext> options)
        : base(options)
        { }

        public DbSet<Client> Clients { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        //optionsBuilder.UseSQLite(@"DataSource=mydatabase.db;");
        }
    }
}
