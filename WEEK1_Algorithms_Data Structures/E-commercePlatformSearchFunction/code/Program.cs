using System;

public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }

    public Product(int productId, string productName, string category)
    {
        ProductId = productId;
        ProductName = productName;
        Category = category;
    }

    public override string ToString()
    {
        return $"ID: {ProductId}, Name: {ProductName}, Category: {Category}";
    }
}

class Program
{
    // Linear search method (case-insensitive)
    public static int LinearSearch(Product[] products, string targetName)
    {
        for (int i = 0; i < products.Length; i++)
        {
            if (products[i].ProductName.Equals(targetName, StringComparison.OrdinalIgnoreCase))
                return i;
        }
        return -1;
    }

    // Binary search method (requires sorted array, case-insensitive)
    public static int BinarySearch(Product[] products, string targetName)
    {
        int left = 0, right = products.Length - 1;
        while (left <= right)
        {
            int mid = (left + right) / 2;
            int comparison = string.Compare(products[mid].ProductName, targetName, StringComparison.OrdinalIgnoreCase);

            if (comparison == 0)
                return mid;
            else if (comparison < 0)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return -1;
    }

    static void Main(string[] args)
    {
        // Sample products
        Product[] products = new Product[]
        {
            new Product(1, "Laptop", "Electronics"),
            new Product(2, "Shoes", "Footwear"),
            new Product(3, "Watch", "Accessories"),
            new Product(4, "Book", "Stationery"),
            new Product(5, "Phone", "Electronics")
        };

        Console.WriteLine("Products List:");
        foreach (var p in products)
            Console.WriteLine(p);

        Console.Write("\nEnter product name to search: ");
        string searchFor = Console.ReadLine();

        // Linear Search
        int linearIndex = LinearSearch(products, searchFor);
        if (linearIndex != -1)
            Console.WriteLine($"\n[Linear Search] Found: {products[linearIndex]} (Index {linearIndex})");
        else
            Console.WriteLine("\n[Linear Search] Product not found.");

        // Sort products by ProductName for binary search
        Array.Sort(products, (a, b) => string.Compare(a.ProductName, b.ProductName, StringComparison.OrdinalIgnoreCase));

        // Binary Search
        int binaryIndex = BinarySearch(products, searchFor);
        if (binaryIndex != -1)
            Console.WriteLine($"[Binary Search] Found: {products[binaryIndex]} (Index {binaryIndex} in sorted array)");
        else
            Console.WriteLine("[Binary Search] Product not found.");
    }
}
