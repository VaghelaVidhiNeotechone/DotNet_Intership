using System.ComponentModel.DataAnnotations;

namespace CompanyModule.Models.DTO
{
    public class CompanyAttachment : DTOBaseModel
    {
        [Key]
        public Guid attachmentid { get; set; }
        public string filename { get; set; } = string.Empty;
        public string filepath { get; set; } = string.Empty;
        public string filetype { get; set; } = string.Empty;
        public Guid companyid { get; set; }

        // Navigation properties
        public virtual CompanyDetailEntity? CompanyDetail { get; set; }
    }
}