using System.ComponentModel.DataAnnotations;

namespace WebApiValidationDemo.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters")]
        public string Name { get; set; }

        [Range(1, 100000, ErrorMessage = "Price must be between 1 and 100000")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Category can't exceed 50 characters")]
        public string Category { get; set; }
    }
}
