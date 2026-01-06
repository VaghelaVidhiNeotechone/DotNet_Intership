using System.ComponentModel.DataAnnotations;

namespace CompanyModule.Models.DTO
{
    public class DTOBaseModel
    {
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;
    }
}
