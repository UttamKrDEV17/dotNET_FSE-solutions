using StoreManagement.Data;
using StoreManagement.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Store Management System - Lab 4: Inserting Initial Data");
Console.WriteLine("========================================================");

try
{
    using var context = new AppDbContext();
    
    // Ensure database is created
    Console.WriteLine("Ensuring database exists...");
    await context.Database.EnsureCreatedAsync();
    
    // Check if data already exists to avoid duplicates
    if (await context.Categories.AnyAsync())
    {
        Console.WriteLine("Data already exists in the database. Skipping insertion.");
        return;
    }
    
    Console.WriteLine("Inserting initial data...");
    
    // Create categories
    var electronics = new Category { Name = "Electronics" };
    var groceries = new Category { Name = "Groceries" };
    
    // Add categories to context
    await context.Categories.AddRangeAsync(electronics, groceries);
    
    // Create products
    var product1 = new Product 
    { 
        Name = "Laptop", 
        Price = 75000, 
        Category = electronics 
    };
    
    var product2 = new Product 
    { 
        Name = "Rice Bag", 
        Price = 1200, 
        Category = groceries 
    };
    
    // Add products to context
    await context.Products.AddRangeAsync(product1, product2);
    
    // Save all changes to database
    await context.SaveChangesAsync();
    
    Console.WriteLine("Data inserted successfully!");
    Console.WriteLine($"Categories added: {electronics.Name}, {groceries.Name}");
    Console.WriteLine($"Products added: {product1.Name} (₹{product1.Price}), {product2.Name} (₹{product2.Price})");
    
    // Verify the data
    Console.WriteLine("\nVerifying inserted data:");
    var categoriesCount = await context.Categories.CountAsync();
    var productsCount = await context.Products.CountAsync();
    
    Console.WriteLine($"Total categories in database: {categoriesCount}");
    Console.WriteLine($"Total products in database: {productsCount}");
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
    Console.WriteLine($"Stack trace: {ex.StackTrace}");
}

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();
