using AutoMapper;
using CompanyModule.Controllers.Version1.UserRole;
using CompanyModule.Models.POCO.Request.UserRole;
using CompanyModule.Models.POCO.Response.UserRole;

namespace CompanyModule.Resources.AutoMapper
{
    public class UserRoleMapper : Profile
    {
        public UserRoleMapper()
        {
            CreateMap<UserRoleController, UserRoleResponse>();
            CreateMap<UserRoleRequest, UserRoleController>();
        }
    }
}
