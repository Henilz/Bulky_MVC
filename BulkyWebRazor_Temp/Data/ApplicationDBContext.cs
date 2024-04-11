using BulkyWebRazor_Temp.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWebRazor_Temp.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) 
        {
            
        }

        public DbSet<Category> categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 6, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 7, Name = "Sci-Fi", DisplayOrder = 1 },
                new Category { Id = 89, Name = "History", DisplayOrder = 1 }
                );
        }

    }
}
