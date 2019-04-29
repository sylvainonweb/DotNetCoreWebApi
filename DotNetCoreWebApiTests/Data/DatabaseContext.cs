﻿using Microsoft.EntityFrameworkCore;

namespace DotNetCoreWebApiTests.Data
{
    public class DatabaseContext : Microsoft.EntityFrameworkCore.DbContext
    {
        private string connectionString;

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }

        public DatabaseContext(string connectionString) : base()
        {
            this.connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.connectionString);

            // La commande suivante (génération des entités à partir de la base) ne fonctionne plus (https://github.com/aspnet/EntityFrameworkCore/issues/15414)
            // et sera normalement corrigé dans la Preview 5 (livraison ???)
            // Scaffold - DbContext "Server=SBLANCHARD01\SQLEXPRESS_2016;Database=WebTestsDatabase;persist security info=True;user id=sa; password=**DLMSOFT2005" Microsoft.EntityFrameworkCore.SqlServer -Context DatabaseContext -OutputDir Data
        }
    }
}
