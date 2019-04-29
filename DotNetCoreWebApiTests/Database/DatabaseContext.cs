using DotNetCoreWebApiTests.Shared;
using Microsoft.EntityFrameworkCore;
using System;

namespace DotNetCoreWebApiTests.Database
{
    /// <summary>
    /// Article utile pour la mise en place d'EF Core avec un projet .net core
    /// https://www.supinfo.com/articles/single/7180-utilisation-entity-framework-core-avec-sql-server-net-core
    /// </summary>
    public class DatabaseContext : Microsoft.EntityFrameworkCore.DbContext, IDisposable
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
    }
}
