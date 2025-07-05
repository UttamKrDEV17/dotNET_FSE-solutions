using System.ComponentModel.DataAnnotations;

namespace RetailStore.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        
        [StringLength(500)]
        public string Description { get; set; }
        
        // Navigation property
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
