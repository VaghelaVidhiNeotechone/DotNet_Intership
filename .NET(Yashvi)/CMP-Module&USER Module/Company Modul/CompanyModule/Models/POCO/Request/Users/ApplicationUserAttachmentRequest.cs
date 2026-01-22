namespace CompanyModule.Models.POCO.Request.Users
{
    public class ApplicationUserAttachmentRequest
    {
        public Guid AttachmentId { get; set; }
        public IFormFile? ProfilePhoto { get; set; }
        public string? imagepath { get; set; }
        public Guid UserId { get; set; }
    }
}
