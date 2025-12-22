using System.ComponentModel.DataAnnotations;

namespace Company_module.Models.DTO
{
    public class CompanyAttachment : DTOBaseModel
    {
        [Key]
        public Guid attachmentid { get; set; }
        public string filename { get; set; }
        public string filepath { get; set; }
        public string filetype { get; set; }

        // FK
        public Guid companyid { get; set; }

        public virtual CompanyDetailEntity CompanyDetail { get; set; }
    }
}
