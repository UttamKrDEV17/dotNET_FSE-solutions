using Microsoft.EntityFrameworkCore;
using Lab6_EFCore_UpdateDelete.Models;

namespace Lab6_EFCore_UpdateDelete.Data
{
    public class StoreContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=BT-22051474\\SQLEXPRESS;Database=StoreDB;Trusted_Connection=true;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Description).HasMaxLength(500);
            });

            // Seed initial data
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Price = 65000, Description = "High-performance laptop" },
                new Product { Id = 2, Name = "Rice Bag", Price = 2500, Description = "Premium quality rice" },
                new Product { Id = 3, Name = "Mobile Phone", Price = 25000, Description = "Latest smartphone" },
                new Product { Id = 4, Name = "Headphones", Price = 3500, Description = "Wireless headphones" }
            );
        }
    }
}
