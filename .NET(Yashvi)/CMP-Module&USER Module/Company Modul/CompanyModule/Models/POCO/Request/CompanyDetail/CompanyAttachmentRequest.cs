using System.ComponentModel.DataAnnotations;

namespace CompanyModule.Models.POCO.Request.CompanyDetail
{
    public class CompanyAttachmentRequest
    {
        public Guid attachmentid { get; set; }

        [Required(ErrorMessage = "Company name is required")]
        public string companyname { get; set; }

        [Required(ErrorMessage = "File name is required")]
        public string filename { get; set; }

        [Required(ErrorMessage = "File type is required")]
        public string filetype { get; set; }
    }
}
