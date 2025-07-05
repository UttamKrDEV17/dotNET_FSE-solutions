using Microsoft.EntityFrameworkCore;
using RetailStore.Models;

namespace RetailStore.Data
{
    public class RetailStoreContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Replace with your actual connection string
            optionsBuilder.UseSqlServer(@"Server=BT-22051474\SQLEXPRESS;Database=RetailStoreDB;Trusted_Connection=true;TrustServerCertificate=true;");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);
                
            // Seed data
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Electronics", Description = "Electronic devices and accessories" },
                new Category { CategoryId = 2, Name = "Clothing", Description = "Apparel and fashion items" }
            );
            
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, Name = "Laptop", Description = "High-performance laptop", Price = 999.99m, Stock = 10, CategoryId = 1 },
                new Product { ProductId = 2, Name = "T-Shirt", Description = "Cotton t-shirt", Price = 19.99m, Stock = 50, CategoryId = 2 }
            );
        }
    }
}
