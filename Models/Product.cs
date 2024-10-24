namespace ProductInventoryManagement.Models
{
    public class Product
    {
        public int ProductID { get; set; } // Primary key
        public string SKU { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        // Navigation property for the relationship
        public ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
    }

    public class ProductCategory
    {
        public int ProductCategoryID { get; set; } // Primary key for the join table

        public int ProductID { get; set; } // Foreign key to Product
        public Product Product { get; set; } // Navigation property

        public int CategoryID { get; set; } // Foreign key to Category
        public Category Category { get; set; } // Navigation property
    }
}
