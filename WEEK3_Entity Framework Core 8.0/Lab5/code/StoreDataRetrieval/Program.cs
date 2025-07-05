using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StoreDataRetrieval.Data;
using StoreDataRetrieval.Models;

namespace StoreDataRetrieval
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

            // Setup dependency injection
            var services = new ServiceCollection();
            services.AddDbContext<StoreContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            var serviceProvider = services.BuildServiceProvider();

            // Get database context
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<StoreContext>();

            // Ensure database is created and seeded
            await context.Database.EnsureCreatedAsync();

            Console.WriteLine("=== Store Product Dashboard ===\n");

            // Lab Exercise Implementation
            await RetrieveAllProducts(context);
            await FindProductById(context);
            await FindExpensiveProduct(context);
        }

        // Step 1: Retrieve All Products
        static async Task RetrieveAllProducts(StoreContext context)
        {
            Console.WriteLine("1. All Products:");
            Console.WriteLine("================");
            
            var products = await context.Products.ToListAsync();
            
            foreach (var p in products)
            {
                Console.WriteLine($"{p.Name} - ₹{p.Price:N0}");
            }
            
            Console.WriteLine($"\nTotal Products: {products.Count}\n");
        }

        // Step 2: Find by ID
        static async Task FindProductById(StoreContext context)
        {
            Console.WriteLine("2. Find Product by ID (ID: 1):");
            Console.WriteLine("===============================");
            
            var product = await context.Products.FindAsync(1);
            
            if (product != null)
            {
                Console.WriteLine($"Found: {product.Name}");
                Console.WriteLine($"Price: ₹{product.Price:N0}");
                Console.WriteLine($"Description: {product.Description}");
            }
            else
            {
                Console.WriteLine("Product not found!");
            }
            
            Console.WriteLine();
        }

        // Step 3: FirstOrDefault with Condition
        static async Task FindExpensiveProduct(StoreContext context)
        {
            Console.WriteLine("3. Find Expensive Product (Price > ₹50,000):");
            Console.WriteLine("==============================================");
            
            var expensive = await context.Products
                .FirstOrDefaultAsync(p => p.Price > 50000);
            
            if (expensive != null)
            {
                Console.WriteLine($"Expensive Product: {expensive.Name}");
                Console.WriteLine($"Price: ₹{expensive.Price:N0}");
                Console.WriteLine($"Description: {expensive.Description}");
            }
            else
            {
                Console.WriteLine("No expensive products found!");
            }
            
            Console.WriteLine();
        }
    }
}
