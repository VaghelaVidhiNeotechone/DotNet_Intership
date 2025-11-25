using System.ComponentModel.DataAnnotations;

namespace Validation_and_Routing.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product Name is required.")]
        [StringLength(50, ErrorMessage = "Product Name can be a maximum of 50 characters.")]
        public string Name { get; set; }

        [Range(1, 1000, ErrorMessage = "Price must be between 1 and 1000.")]
        public decimal Price { get; set; }
    }
}
