using CompanyModule.Models.Common;

namespace CompanyModule.Models.POCO.Request.UserRole
{
    public class UserRoleFilterModel : PaggingRequestModel
    {
        public string? search { get; set; }
        public List<UserRoleSearchParameter>? searchParameters { get; set; } = new List<UserRoleSearchParameter>();
        public string sortField { get; set; }
        public bool isAscending { get; set; }
        public Guid? companyid { get; set; }
    }

    public class UserRoleSearchParameter
    {
        public string Key { get; set; }
        public object Value { get; set; }
    }
}
