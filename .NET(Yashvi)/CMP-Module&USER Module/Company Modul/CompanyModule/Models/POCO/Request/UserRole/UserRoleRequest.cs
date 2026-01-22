using CompanyModule.Models.Enums;

namespace CompanyModule.Models.POCO.Request.UserRole
{
    public class UserRoleRequest
    {
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public Guid CompanyId { get; set; }
        public Status StatusId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
