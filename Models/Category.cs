using System.ComponentModel.DataAnnotations;

namespace ProductInventoryManagement.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; } 
        public string Name { get; set; }

       
        public ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
    }

}
