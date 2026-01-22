using System.ComponentModel.DataAnnotations;

namespace CompanyModule.Models.DTO
{
    public class UserFile : DTOBaseModel
    {
        [Key]
        public Guid userfileid { get; set; }
        public Guid fileid => userfileid;
        public Guid userid { get; set; }
        public string filename { get; set; } = string.Empty;
        public string filepath { get; set; } = string.Empty;
        public string filetype { get; set; } = string.Empty;
        public long filesize { get; set; }
        public string description { get; set; } = string.Empty;

        // Navigation properties
        public virtual ApplicationUser? User { get; set; }
    }
}