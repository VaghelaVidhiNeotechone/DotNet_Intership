using System.ComponentModel.DataAnnotations;

namespace CompanyModule.Models.POCO.Request.Users
{
    public class AuthenticateRequest
    {
        [Required]
        public string email { get; set; }

        [Required]
        public string password { get; set; }
        [Required]
        public Guid companyid { get; set; }
    }
}
