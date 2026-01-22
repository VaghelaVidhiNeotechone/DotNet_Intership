namespace CompanyModule.Models.POCO.Request.Users
{
    public class ApplicationUserChangePasswordRequest
    {
        public string oldpassword { get; set; }
        public string newpassword { get; set; }
    }
}
