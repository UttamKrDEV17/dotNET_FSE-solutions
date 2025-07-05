using System;
using System.Linq;

class Program
{
    static void Main()
    {
        
        using var db = new RetailContext();

        // Add this at the beginning of Main() to start fresh each time
        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();


        // Add a category
        var category = new Category { Name = "Electronics" };
        db.Categories.Add(category);
        db.SaveChanges();

        // Add a product
        var product = new Product { Name = "Book", StockLevel = 13, CategoryId = category.Id };
        db.Products.Add(product);
        db.SaveChanges();

        // Query products
        var products = db.Products
                         .Where(p => p.StockLevel > 0)
                         .Select(p => new { p.Name, p.StockLevel })
                         .ToList();

        foreach (var p in products)
        {
            Console.WriteLine($"{p.Name} - Stock: {p.StockLevel}");
        }
    }
}
