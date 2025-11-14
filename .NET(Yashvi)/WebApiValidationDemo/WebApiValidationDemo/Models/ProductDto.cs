using System.ComponentModel.DataAnnotations;

namespace WebApiValidationDemo.Models
{
    public class ProductDto
    {
        [Required(ErrorMessage = "Product name is required")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long")]
        public string Name { get; set; }

        [Range(1, 100000, ErrorMessage = "Price must be between 1 and 100000")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Category is required")]
        [MinLength(3, ErrorMessage = "Category must be at least 3 characters long")]
        public string Category { get; set; }
    }
}
