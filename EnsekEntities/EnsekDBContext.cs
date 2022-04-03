using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnsekEntities
{
    public class EnsekDBContext : DbContext
    {
        public EnsekDBContext(DbContextOptions<EnsekDBContext> options) : base(options)
        {
        }

        public EnsekDBContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sri\source\repos\EnsekEntities\AppData\EnsekDatabase.mdf;Integrated Security=True");
            }
        }
        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<MeterReadings> MeterReadings { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(builder);

            builder.Entity<Accounts>().HasData(new Accounts() { AccountId = 1234, FirstName = "Freya", LastName = "Test" });
            builder.Entity<Accounts>().HasData(new Accounts() { AccountId = 1239, FirstName = "Noddy", LastName = "Test" });
            builder.Entity<Accounts>().HasData(new Accounts() { AccountId = 1240, FirstName = "Archie", LastName = "Test" });
            builder.Entity<Accounts>().HasData(new Accounts() { AccountId = 1241, FirstName = "Lara", LastName = "Test" });
            builder.Entity<Accounts>().HasData(new Accounts() { AccountId = 1242, FirstName = "Tim", LastName = "Test" });
            builder.Entity<Accounts>().HasData(new Accounts() { AccountId = 1243, FirstName = "Graham", LastName = "Test" });
            builder.Entity<Accounts>().HasData(new Accounts() { AccountId = 1244, FirstName = "Tony", LastName = "Test" });
            builder.Entity<Accounts>().HasData(new Accounts() { AccountId = 1245, FirstName = "Neville", LastName = "Test" });
            builder.Entity<Accounts>().HasData(new Accounts() { AccountId = 1246, FirstName = "Jo", LastName = "Test" });
            builder.Entity<Accounts>().HasData(new Accounts() { AccountId = 1247, FirstName = "Jim", LastName = "Test" });
            builder.Entity<Accounts>().HasData(new Accounts() { AccountId = 1248, FirstName = "Pam", LastName = "Test" });
            builder.Entity<Accounts>().HasData(new Accounts() { AccountId = 2233, FirstName = "Barry", LastName = "Test" });
            builder.Entity<Accounts>().HasData(new Accounts() { AccountId = 2344, FirstName = "Tommy", LastName = "Test" });
            builder.Entity<Accounts>().HasData(new Accounts() { AccountId = 2345, FirstName = "Jerry", LastName = "Test" });
            builder.Entity<Accounts>().HasData(new Accounts() { AccountId = 2346, FirstName = "Ollie", LastName = "Test" });
            builder.Entity<Accounts>().HasData(new Accounts() { AccountId = 2347, FirstName = "Tara", LastName = "Test" });
            builder.Entity<Accounts>().HasData(new Accounts() { AccountId = 2348, FirstName = "Tammy", LastName = "Test" });
            builder.Entity<Accounts>().HasData(new Accounts() { AccountId = 2349, FirstName = "Simon", LastName = "Test" });
            builder.Entity<Accounts>().HasData(new Accounts() { AccountId = 2350, FirstName = "Colin", LastName = "Test" });
            builder.Entity<Accounts>().HasData(new Accounts() { AccountId = 2351, FirstName = "Gladys", LastName = "Test" });
            builder.Entity<Accounts>().HasData(new Accounts() { AccountId = 2352, FirstName = "Greg", LastName = "Test" });
            builder.Entity<Accounts>().HasData(new Accounts() { AccountId = 2353, FirstName = "Tony", LastName = "Test" });
            builder.Entity<Accounts>().HasData(new Accounts() { AccountId = 2355, FirstName = "Arthur", LastName = "Test" });
            builder.Entity<Accounts>().HasData(new Accounts() { AccountId = 2356, FirstName = "Craig", LastName = "Test" });
            builder.Entity<Accounts>().HasData(new Accounts() { AccountId = 4534, FirstName = "JOSH", LastName = "TEST" });
            builder.Entity<Accounts>().HasData(new Accounts() { AccountId = 6776, FirstName = "Laura", LastName = "Test" });
            builder.Entity<Accounts>().HasData(new Accounts() { AccountId = 8766, FirstName = "Sally", LastName = "Test" });
        }

    }
}
