using DotNetCoreWebApiTests.Shared;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreWebApiTests.Database
{
    /// <summary>
    /// Article utile pour la mise en place d'EF Core avec un projet .net core
    /// https://www.supinfo.com/articles/single/7180-utilisation-entity-framework-core-avec-sql-server-net-core
    /// </summary>
    public class DatabaseContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public string ConnectionString { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }

        public DatabaseContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.ConnectionString);

            // La commande suivante (génération des entités à partir de la base) ne fonctionne plus (https://github.com/aspnet/EntityFrameworkCore/issues/15414)
            // et sera normalement corrigé dans la Preview 5 (livraison ???)
            // Scaffold - DbContext "Server=SBLANCHARD01\SQLEXPRESS_2016;Database=WebTestsDatabase;persist security info=True;user id=sa; password=**DLMSOFT2005" Microsoft.EntityFrameworkCore.SqlServer -Context DatabaseContext -OutputDir Data
        }
    }
}
