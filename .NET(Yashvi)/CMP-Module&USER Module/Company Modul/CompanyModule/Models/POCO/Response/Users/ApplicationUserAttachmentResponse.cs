namespace CompanyModule.Models.POCO.Response.Users
{
    public class ApplicationUserAttachmentResponse
    {
        public Guid AttachmentId { get; set; }
        public string? imagepath { get; set; }
        //public string ProfilePhoto { get; set; }
        public Guid UserId { get; set; }
    }
}
