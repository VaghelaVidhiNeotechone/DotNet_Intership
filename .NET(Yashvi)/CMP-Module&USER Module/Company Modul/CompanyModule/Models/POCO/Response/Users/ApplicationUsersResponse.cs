using CompanyModule.Models.Enums;
using System.Reflection;

namespace CompanyModule.Models.POCO.Response.Users
{
    public class ApplicationUsersResponse
    {
        public Guid userid { get; set; }
        public string fullname { get; set; }
        public string username { get; set; }
        public string Password { get; set; }
        public string email { get; set; }
        public DateTime? dateofbirth { get; set; }
        public Gender gender { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public Status StatusId { get; set; }
        public bool IsDeleted { get; set; }
        public Guid companyid { get; set; }
        public string companyname { get; set; }
        public Guid? UserRoleId { get; set; }
        public List<string> userroles { get; set; } = new List<string>();
    }
}
