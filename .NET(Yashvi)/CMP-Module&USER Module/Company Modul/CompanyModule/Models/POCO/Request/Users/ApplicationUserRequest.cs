using CompanyModule.Models.Enums;
using System.Reflection;

namespace CompanyModule.Models.POCO.Request.Users
{
    public class ApplicationUserRequest
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public Guid CompanyId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public Guid? UserRoleId { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public Status StatusId { get; set; }
    }
}
