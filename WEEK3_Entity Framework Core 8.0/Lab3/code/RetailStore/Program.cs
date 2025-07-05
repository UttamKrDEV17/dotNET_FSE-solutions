using RetailStore.Data;
using RetailStore.Models;

namespace RetailStore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Retail Store Database Management");
            
            using (var context = new RetailStoreContext())
            {
                // Test database connection
                try
                {
                    var categoryCount = context.Categories.Count();
                    var productCount = context.Products.Count();
                    
                    Console.WriteLine($"Database connected successfully!");
                    Console.WriteLine($"Categories: {categoryCount}");
                    Console.WriteLine($"Products: {productCount}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Database connection failed: {ex.Message}");
                }
            }
        }
    }
}
