import java.util.Arrays;
import java.util.Comparator;

class Product {
    private int productId;
    private String productName;
    private String category;

    public Product(int productId, String productName, String category) {
        this.productId = productId;
        this.productName = productName;
        this.category = category;
    }

    public String getProductName() {
        return productName;
    }

    @Override
    public String toString() {
        return "ID: " + productId + ", Name: " + productName + ", Category: " + category;
    }
}

class ECommerceSearch {
    // Linear Search
    public static Product linearSearch(Product[] products, String targetName) {
        for (Product product : products) {
            if (product.getProductName().equalsIgnoreCase(targetName)) {
                return product;
            }
        }
        return null;
    }

    // Binary Search (requires sorted array)
    public static Product binarySearch(Product[] products, String targetName) {
        int left = 0, right = products.length - 1;
        while (left <= right) {
            int mid = left + (right - left) / 2;
            int cmp = products[mid].getProductName().compareToIgnoreCase(targetName);
            if (cmp == 0) {
                return products[mid];
            } else if (cmp < 0) {
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }
        return null;
    }

    // Sort products by ProductName (for binary search)
    public static void sortProductsByName(Product[] products) {
        Arrays.sort(products, Comparator.comparing(Product::getProductName, String.CASE_INSENSITIVE_ORDER));
    }
}

public class ECommerceSearchDemo {
    public static void main(String[] args) {
        Product[] products = new Product[]{
            new Product(1, "Laptop", "Electronics"),
            new Product(2, "Keyboard", "Electronics"),
            new Product(3, "Chair", "Furniture"),
            new Product(4, "Book", "Stationery"),
            new Product(5, "Mouse", "Electronics")
        };

        System.out.println("=== Linear Search ===");
        String searchName = "Chair";
        Product foundProduct = ECommerceSearch.linearSearch(products, searchName);
        if (foundProduct != null)
            System.out.println("Product found: " + foundProduct);
        else
            System.out.println("Product not found.");

        System.out.println("\n=== Binary Search ===");
        // Sort the array before binary search
        ECommerceSearch.sortProductsByName(products);

        searchName = "Book";
        foundProduct = ECommerceSearch.binarySearch(products, searchName);
        if (foundProduct != null)
            System.out.println("Product found: " + foundProduct);
        else
            System.out.println("Product not found.");
    }
}
