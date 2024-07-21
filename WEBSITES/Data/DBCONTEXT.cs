using Microsoft.EntityFrameworkCore;
using System.Xml;
using WEBSITES.Models;

namespace WEBSITES.Data
{
    public class DBCONTEXT : DbContext
    {
        public DBCONTEXT(DbContextOptions<DBCONTEXT> options): base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product {Id  = 1,  Name = "Laptop", ExpiryDate = DateTime.Now.AddYears(2), CategoryId = 12 },
                new Product { Id = 2, Name = "Smartphone", ExpiryDate = DateTime.Now.AddYears(1), CategoryId = 12 },
                new Product { Id = 3, Name = "Novel", ExpiryDate = DateTime.Now.AddYears(5), CategoryId = 12 },
                new Product { Id = 4, Name = "T-Shirt", ExpiryDate = DateTime.Now.AddYears(3), CategoryId = 12 }
            );
        }
    }
}
