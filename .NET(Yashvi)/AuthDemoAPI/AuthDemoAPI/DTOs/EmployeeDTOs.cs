using System.ComponentModel.DataAnnotations;

namespace AuthDemoAPI.DTOs
{
    public class CreateEmployeeDto
    {
        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Department { get; set; }

        [Required]
        public decimal Salary { get; set; }
    }

    public class UpdateEmployeeDto : CreateEmployeeDto { }

}
