using CompanyModule.Models.Enums;

namespace CompanyModule.Models.POCO.Response.UserRole
{
    public class UserRoleResponse
    {
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }
        public Status StatusId { get; set; }
        public bool IsDeleted { get; set; }
        //public IList<PermissionResponse> Permissions { get; set; }
        //public IList<int> Permissions { get; set; }
    }
}
