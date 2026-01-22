using System.ComponentModel.DataAnnotations;

namespace CompanyModule.Models.DTO
{
    public class OtpMaster : DTOBaseModel
    {
        [Key]
        public Guid OtpId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string OtpCode { get; set; } = string.Empty;
        public DateTime ExpiryTime { get; set; }
        public bool IsUsed { get; set; } = false;
    }
}