using System.ComponentModel.DataAnnotations;

namespace CompanyModule.Models.DTO
{
    public class CompanyAttachment : DTOBaseModel
    {
        [Key]
        public Guid attachmentid { get; set; }
        public string filename { get; set; }
        public string filepath { get; set; }
        public string filetype { get; set; }

        
        public Guid companyid { get; set; }

        public virtual CompanyDetailEntity CompanyDetail { get; set; }
    }
}
