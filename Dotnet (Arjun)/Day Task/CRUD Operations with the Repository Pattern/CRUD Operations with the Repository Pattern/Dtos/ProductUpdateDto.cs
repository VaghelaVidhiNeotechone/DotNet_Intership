using System.ComponentModel.DataAnnotations;

namespace CRUD_Operations_with_the_Repository_Pattern.Dtos
{
    public class ProductUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        [Range(1, 100000)]
        public decimal Price { get; set; }
    }
}
