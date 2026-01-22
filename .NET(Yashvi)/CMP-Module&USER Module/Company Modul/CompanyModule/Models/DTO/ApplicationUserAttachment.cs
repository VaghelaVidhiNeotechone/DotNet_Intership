using System.ComponentModel.DataAnnotations;

namespace CompanyModule.Models.DTO
{
    public class ApplicationUserAttachment : DTOBaseModel
    {
        [Key]
        public Guid AttachmentId { get; set; }
        public Guid UserId { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string FileType { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        
        // Navigation property
        public virtual ApplicationUser? User { get; set; }
    }
}