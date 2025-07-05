using Microsoft.EntityFrameworkCore;
using ProductStoreLinq.Data;
using ProductStoreLinq.Services;

namespace ProductStoreLinq
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("=== Product Store LINQ Lab 7 ===\n");

            using var context = new StoreContext();
            
            // Ensure database is created
            await context.Database.EnsureCreatedAsync();
            
            var productService = new ProductService(context);

            try
            {
                // Lab 7 Step 1: Filter and Sort
                var expensiveProducts = await productService.GetExpensiveProductsSortedAsync();
                foreach (var product in expensiveProducts)
                {
                    Console.WriteLine($"Name: {product.Name}, Price: ${product.Price:F2}, Category: {product.Category}");
                }

                // Lab 7 Step 2: Project into DTO
                var productDTOs = await productService.GetProductDTOsAsync();
                foreach (dynamic dto in productDTOs)
                {
                    Console.WriteLine($"Name: {dto.Name}, Price: ${dto.Price:F2}");
                }

                // Additional Examples
                var detailedDTOs = await productService.GetProductDetailDTOsAsync();
                foreach (var dto in detailedDTOs)
                {
                    Console.WriteLine($"ID: {dto.Id}, Name: {dto.Name}, Price: ${dto.Price:F2}, Category: {dto.Category}, Stock: {dto.StockQuantity}");
                }

                var groupedProducts = await productService.GetProductsByCategory();
                foreach (var group in groupedProducts)
                {
                    Console.WriteLine($"\nCategory: {group.Key}");
                    foreach (var product in group)
                    {
                        Console.WriteLine($"  - {product.Name}: ${product.Price:F2}");
                    }
                }

                var stats = await productService.GetProductStatistics();
                Console.WriteLine($"\nStatistics: {stats}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
