using Microsoft.EntityFrameworkCore;
using StoreDataRetrieval.Models;

namespace StoreDataRetrieval.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Price = 75000, Description = "High-performance laptop" },
                new Product { Id = 2, Name = "Mouse", Price = 1500, Description = "Wireless mouse" },
                new Product { Id = 3, Name = "Keyboard", Price = 3000, Description = "Mechanical keyboard" },
                new Product { Id = 4, Name = "Monitor", Price = 25000, Description = "4K Monitor" },
                new Product { Id = 5, Name = "Graphics Card", Price = 60000, Description = "Gaming GPU" }
            );
        }
    }
}
