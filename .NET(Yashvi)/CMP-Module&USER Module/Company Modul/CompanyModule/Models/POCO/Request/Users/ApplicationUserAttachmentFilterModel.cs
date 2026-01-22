using CompanyModule.Models.Common;

namespace CompanyModule.Models.POCO.Request.Users
{
    public class ApplicationUserAttachmentFilterModel : PaggingRequestModel
    {
        public string? search { get; set; }
        public List<UserSearchParameter>? searchParameters { get; set; } = new List<UserSearchParameter>();
        public string sortField { get; set; }
        public bool isAscending { get; set; }
        public Guid? companyid { get; set; }
    }

    public class UserSearchParameter
    {
        public string Key { get; set; }
        public object Value { get; set; }
    }
}
