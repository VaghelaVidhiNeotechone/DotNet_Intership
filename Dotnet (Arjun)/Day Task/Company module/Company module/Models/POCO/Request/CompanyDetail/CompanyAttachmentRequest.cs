namespace Company_module.Models.POCO.Request.CompanyDetail
{
    public class CompanyAttachmentRequest
    {
        public Guid attachmentid { get; set; }
        public Guid companyid { get; set; }
        public string filename { get; set; }
        public string filetype { get; set; }
    }
}
