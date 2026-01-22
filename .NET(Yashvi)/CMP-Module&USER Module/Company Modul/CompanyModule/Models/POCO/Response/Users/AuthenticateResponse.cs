using CompanyModule.Models.DTO;

namespace CompanyModule.Models.POCO.Response.Users
{
    public class AuthenticateResponse
    {

        public Guid id { get; set; }
        public string fullname { get; set; }
        public string username { get; set; }
        public string token { get; set; }
        public string RoleName { get; set; }


        public AuthenticateResponse(ApplicationUser user, string _token)
        {
            id = user.userid;
            fullname = user.fullname;
            username = user.username;
            token = _token;
            RoleName = "";
        }
    }
}
