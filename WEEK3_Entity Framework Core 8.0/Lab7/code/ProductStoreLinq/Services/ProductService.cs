using Microsoft.EntityFrameworkCore;
using ProductStoreLinq.Data;
using ProductStoreLinq.Models;

namespace ProductStoreLinq.Services
{
    public class ProductService
    {
        private readonly StoreContext _context;

        public ProductService(StoreContext context)
        {
            _context = context;
        }

        // Lab 7 Step 1: Filter and Sort Products
        public async Task<List<Product>> GetExpensiveProductsSortedAsync()
        {
            Console.WriteLine("=== Filtering and Sorting Products (Price > 1000) ===");
            
            var filtered = await _context.Products
                .Where(p => p.Price > 1000)
                .OrderByDescending(p => p.Price)
                .ToListAsync();

            return filtered;
        }

        // Lab 7 Step 2: Project into Simple DTO
        public async Task<List<object>> GetProductDTOsAsync()
        {
            Console.WriteLine("\n=== Projecting into Simple DTOs ===");
            
            var productDTOs = await _context.Products
                .Select(p => new { p.Name, p.Price })
                .ToListAsync();

            return productDTOs.Cast<object>().ToList();
        }

        // Additional LINQ Examples for comprehensive learning
        public async Task<List<ProductDetailDto>> GetProductDetailDTOsAsync()
        {
            Console.WriteLine("\n=== Projecting into Detailed DTOs ===");
            
            var detailedDTOs = await _context.Products
                .Where(p => p.IsActive)
                .Select(p => new ProductDetailDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Category = p.Category,
                    StockQuantity = p.StockQuantity
                })
                .OrderBy(p => p.Category)
                .ThenByDescending(p => p.Price)
                .ToListAsync();

            return detailedDTOs;
        }

        public async Task<IGrouping<string, Product>[]> GetProductsByCategory()
        {
            Console.WriteLine("\n=== Grouping Products by Category ===");
            
            var groupedProducts = await _context.Products
                .Where(p => p.IsActive)
                .GroupBy(p => p.Category)
                .ToArrayAsync();

            return groupedProducts;
        }

        public async Task<object> GetProductStatistics()
        {
            Console.WriteLine("\n=== Product Statistics ===");
            
            var stats = await _context.Products
                .Where(p => p.IsActive)
                .GroupBy(p => 1)
                .Select(g => new
                {
                    TotalProducts = g.Count(),
                    AveragePrice = g.Average(p => p.Price),
                    MaxPrice = g.Max(p => p.Price),
                    MinPrice = g.Min(p => p.Price),
                    TotalValue = g.Sum(p => p.Price * p.StockQuantity)
                })
                .FirstOrDefaultAsync();

            return stats ?? new { TotalProducts = 0, AveragePrice = 0m, MaxPrice = 0m, MinPrice = 0m, TotalValue = 0m };
        }
    }
}
