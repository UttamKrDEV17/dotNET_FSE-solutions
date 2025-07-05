using Microsoft.EntityFrameworkCore;
using Lab6_EFCore_UpdateDelete.Data;
using Lab6_EFCore_UpdateDelete.Models;

namespace Lab6_EFCore_UpdateDelete
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("=== Lab 6: Updating and Deleting Records with EF Core ===\n");

            using var context = new StoreContext();

            try
            {
                // Ensure database is created
                await context.Database.EnsureCreatedAsync();
                Console.WriteLine("Database connection established successfully!\n");

                // Display initial products
                await DisplayAllProducts(context);

                // Step 1: Update a Product
                Console.WriteLine("=== STEP 1: Updating Product Price ===");
                await UpdateProductPrice(context);

                // Step 2: Delete a Product
                Console.WriteLine("\n=== STEP 2: Deleting Product ===");
                await DeleteProduct(context);

                // Display final products
                Console.WriteLine("\n=== Final Product List ===");
                await DisplayAllProducts(context);

                Console.WriteLine("\nLab 6 completed successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static async Task UpdateProductPrice(StoreContext context)
        {
            Console.WriteLine("Searching for 'Laptop' to update price...");
            
            var product = await context.Products.FirstOrDefaultAsync(p => p.Name == "Laptop");
            
            if (product != null)
            {
                Console.WriteLine($"Found: {product.Name} - Current Price: ₹{product.Price}");
                
                decimal oldPrice = product.Price;
                product.Price = 70000;
                
                await context.SaveChangesAsync();
                
                Console.WriteLine($"✅ Price updated successfully!");
                Console.WriteLine($"   Old Price: ₹{oldPrice}");
                Console.WriteLine($"   New Price: ₹{product.Price}");
            }
            else
            {
                Console.WriteLine("❌ Product 'Laptop' not found!");
            }
        }

        static async Task DeleteProduct(StoreContext context)
        {
            Console.WriteLine("Searching for 'Rice Bag' to delete...");
            
            var toDelete = await context.Products.FirstOrDefaultAsync(p => p.Name == "Rice Bag");
            
            if (toDelete != null)
            {
                Console.WriteLine($"Found: {toDelete.Name} - Price: ₹{toDelete.Price}");
                
                context.Products.Remove(toDelete);
                await context.SaveChangesAsync();
                
                Console.WriteLine("✅ Product deleted successfully!");
            }
            else
            {
                Console.WriteLine("❌ Product 'Rice Bag' not found!");
            }
        }

        static async Task DisplayAllProducts(StoreContext context)
        {
            var products = await context.Products.ToListAsync();
            
            Console.WriteLine("Current Products in Store:");
            Console.WriteLine("┌────┬─────────────────┬───────────┬─────────────────────────┐");
            Console.WriteLine("│ ID │ Name            │ Price (₹) │ Description             │");
            Console.WriteLine("├────┼─────────────────┼───────────┼─────────────────────────┤");
            
            foreach (var product in products)
            {
                Console.WriteLine($"│ {product.Id,2} │ {product.Name,-15} │ {product.Price,9} │ {product.Description,-23} │");
            }
            
            Console.WriteLine("└────┴─────────────────┴───────────┴─────────────────────────┘");
            Console.WriteLine($"Total Products: {products.Count}\n");
        }
    }
}
