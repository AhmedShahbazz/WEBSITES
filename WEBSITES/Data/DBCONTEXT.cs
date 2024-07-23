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
            // Seed the Categories table
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Books", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Clothing", DisplayOrder = 3 }
            );

            // Seed the Products table with correct CategoryId values
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", ExpiryDate = DateTime.Now.AddYears(2), CategoryId = 1, ImageUrl = "" },
                new Product { Id = 2, Name = "Smartphone", ExpiryDate = DateTime.Now.AddYears(1), CategoryId = 1, ImageUrl = "" },
                new Product { Id = 3, Name = "Novel", ExpiryDate = DateTime.Now.AddYears(5), CategoryId = 2, ImageUrl = "" },
                new Product { Id = 4, Name = "T-Shirt", ExpiryDate = DateTime.Now.AddYears(3), CategoryId = 3, ImageUrl = "" }
            );
        }
}
}
