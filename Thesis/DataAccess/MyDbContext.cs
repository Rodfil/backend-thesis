﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Thesis.Models;

namespace Egorventment.DataAccess
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Documents> Documents { get; set; }
        public DbSet<CreateAccount> CreateAccounts { get; set; }
        public DbSet<Requirements> Requirements { get; set; }
        public DbSet<YourRequest> YourRequests { get; set; }
        public DbSet<PurposeDescription> PurposeDescription { get; set; }

    }

    public class TransportPlanContextDesignFactory : IDesignTimeDbContextFactory<MyDbContext>
    {
        public MyDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=thesisDb;Trusted_Connection=True;TrustServerCertificate=True;");
            //optionsBuilder.UseSqlServer("Server=localhost;Database=SkanlogPHTestDB;Trusted_Connection=True;TrustServerCertificate=True;");

            return new MyDbContext(optionsBuilder.Options);
        }
    }
}