using System.ComponentModel.DataAnnotations;

namespace Company_module.Models.DTO
{
    public class DTOBaseModel
    {
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;
    }
}
