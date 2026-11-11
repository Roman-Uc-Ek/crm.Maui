using Crm.Muai.Models;
using Microsoft.EntityFrameworkCore;

namespace Crm.Muai.Persistence
{
    public class CrmDbContext : DbContext
    {
        //Entidades
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "crm.db");
            optionsBuilder.UseSqlite($"Filename ={dbPath}");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>()
                .ToTable("Customers")
                .HasData(
                new Customer
                {
                    Id = 1,
                    FirstName = "Bruce",
                    LastName = "Wayne",
                    Email = "bruce.wayne@gmail.com"
                },
                new Customer
                {
                    Id = 2,
                    FirstName = "Peter",
                    LastName = "Parker",
                    Email = "peter.parker@gmail.com"
                },
                new Customer
                {
                    Id = 3,
                    FirstName = "Tony",
                    LastName = "Stark",
                    Email = "tony.stark@gmail.com"
                });

        }
    }
}
