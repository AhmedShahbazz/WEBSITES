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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name="Action", DisplayOrder=1},
                new Category { Id = 2, Name = "sci", DisplayOrder = 2 },
                new Category { Id = 3, Name = "history ", DisplayOrder = 3 }

                );
        }
    }
}
