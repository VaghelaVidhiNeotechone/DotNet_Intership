using System.ComponentModel.DataAnnotations;

namespace CRUD_with_WebAPI.DTOs
{
    public class CreateStudentRequestDTO
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name should be max 50 characters.")]
        public string? Name { get; set; }

        [Range(18, 60, ErrorMessage = "Age should be between 18 to 60")]
        public int Age { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string? City { get; set; }
    }
}
