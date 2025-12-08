using System.ComponentModel.DataAnnotations;

namespace CRUD_with_WebAPI.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name should be max 50 characters.")]
        public required string Name { get; set; }

        [Range(18, 60, ErrorMessage = "Age should be between 18 to 60")]
        public int Age { get; set; }

        [Required]
        public required string City { get; set; }
    }
}
