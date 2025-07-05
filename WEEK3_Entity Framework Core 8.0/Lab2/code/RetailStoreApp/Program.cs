using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RetailStoreApp.Data;
using RetailStoreApp.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RetailStoreApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Build configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Configure services
            var services = new ServiceCollection();
            ConfigureServices(services, configuration);

            // Build service provider
            var serviceProvider = services.BuildServiceProvider();

            // Get the DbContext
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            // Ensure database is created
            await context.Database.EnsureCreatedAsync();

            // Seed data if needed
            await SeedDataAsync(context);

            // Demonstrate CRUD operations
            await DemonstrateCrudOperations(context);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        private static async Task SeedDataAsync(AppDbContext context)
        {
            // Check if data already exists
            if (context.Categories.Any())
                return;

            // Add sample categories
            var categories = new[]
            {
                new Category { Name = "Electronics" },
                new Category { Name = "Clothing" },
                new Category { Name = "Books" }
            };

            context.Categories.AddRange(categories);
            await context.SaveChangesAsync();

            // Add sample products
            var products = new[]
            {
                new Product { Name = "Laptop", Price = 999.99m, CategoryId = 1 },
                new Product { Name = "Smartphone", Price = 699.99m, CategoryId = 1 },
                new Product { Name = "T-Shirt", Price = 19.99m, CategoryId = 2 },
                new Product { Name = "Jeans", Price = 49.99m, CategoryId = 2 },
                new Product { Name = "Programming Book", Price = 39.99m, CategoryId = 3 }
            };

            context.Products.AddRange(products);
            await context.SaveChangesAsync();

            Console.WriteLine("Sample data seeded successfully!");
        }

        private static async Task DemonstrateCrudOperations(AppDbContext context)
        {
            Console.WriteLine("\n=== Demonstrating CRUD Operations ===\n");

            // READ: Display all products with their categories
            Console.WriteLine("All Products:");
            var products = await context.Products
                .Include(p => p.Category)
                .ToListAsync();

            foreach (var product in products)
            {
                Console.WriteLine($"- {product.Name} (${product.Price}) - Category: {product.Category.Name}");
            }

            // CREATE: Add a new product
            var newProduct = new Product
            {
                Name = "Wireless Headphones",
                Price = 149.99m,
                CategoryId = 1 // Electronics
            };

            context.Products.Add(newProduct);
            await context.SaveChangesAsync();
            Console.WriteLine($"\nAdded new product: {newProduct.Name}");

            // UPDATE: Update a product price
            var productToUpdate = await context.Products.FirstOrDefaultAsync(p => p.Name == "Laptop");
            if (productToUpdate != null)
            {
                var oldPrice = productToUpdate.Price;
                productToUpdate.Price = 899.99m;
                await context.SaveChangesAsync();
                Console.WriteLine($"Updated {productToUpdate.Name} price from ${oldPrice} to ${productToUpdate.Price}");
            }

            // DELETE: Remove a product
            var productToDelete = await context.Products.FirstOrDefaultAsync(p => p.Name == "T-Shirt");
            if (productToDelete != null)
            {
                context.Products.Remove(productToDelete);
                await context.SaveChangesAsync();
                Console.WriteLine($"Deleted product: {productToDelete.Name}");
            }

            // Display updated product list
            Console.WriteLine("\nUpdated Product List:");
            var updatedProducts = await context.Products
                .Include(p => p.Category)
                .ToListAsync();

            foreach (var product in updatedProducts)
            {
                Console.WriteLine($"- {product.Name} (${product.Price}) - Category: {product.Category.Name}");
            }
        }
    }
}
