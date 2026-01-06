namespace CompanyModule.Models.POCO.Request.CompanyDetail
{
    public class CompanyAttachmentRequest
    {
        public Guid attachmentid { get; set; }
        public string companyname { get; set; } = string.Empty;
        public string filename { get; set; } = string.Empty;
        public string filetype { get; set; } = string.Empty;
    }
}
