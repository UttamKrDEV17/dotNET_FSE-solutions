using Microsoft.EntityFrameworkCore;
using ProductStoreLinq.Models;

namespace ProductStoreLinq.Data
{
    public class StoreContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=BT-22051474\\SQLEXPRESS;Database=ProductStore;Trusted_Connection=true;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Category).HasMaxLength(100);
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
            });

            // Seed data
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Gaming Laptop", Price = 1500.00m, Category = "Electronics", StockQuantity = 10, CreatedDate = DateTime.Now.AddDays(-30), IsActive = true },
                new Product { Id = 2, Name = "Wireless Mouse", Price = 25.99m, Category = "Electronics", StockQuantity = 50, CreatedDate = DateTime.Now.AddDays(-20), IsActive = true },
                new Product { Id = 3, Name = "4K Monitor", Price = 800.00m, Category = "Electronics", StockQuantity = 15, CreatedDate = DateTime.Now.AddDays(-15), IsActive = true },
                new Product { Id = 4, Name = "Mechanical Keyboard", Price = 120.00m, Category = "Electronics", StockQuantity = 25, CreatedDate = DateTime.Now.AddDays(-10), IsActive = true },
                new Product { Id = 5, Name = "Professional Camera", Price = 2500.00m, Category = "Photography", StockQuantity = 5, CreatedDate = DateTime.Now.AddDays(-5), IsActive = true },
                new Product { Id = 6, Name = "Smartphone", Price = 1200.00m, Category = "Electronics", StockQuantity = 30, CreatedDate = DateTime.Now.AddDays(-25), IsActive = true },
                new Product { Id = 7, Name = "Tablet", Price = 600.00m, Category = "Electronics", StockQuantity = 20, CreatedDate = DateTime.Now.AddDays(-12), IsActive = true },
                new Product { Id = 8, Name = "Headphones", Price = 150.00m, Category = "Audio", StockQuantity = 40, CreatedDate = DateTime.Now.AddDays(-8), IsActive = true }
            );
        }
    }
}
