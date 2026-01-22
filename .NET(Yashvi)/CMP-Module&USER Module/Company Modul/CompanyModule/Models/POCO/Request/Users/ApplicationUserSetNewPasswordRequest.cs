namespace CompanyModule.Models.POCO.Request.Users
{
    public class ApplicationUserSetNewPasswordRequest
    {
        public string username { get; set; }
        public string newpassword { get; set; }
    }
}
