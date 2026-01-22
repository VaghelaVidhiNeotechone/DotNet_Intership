using AutoMapper;
using CompanyModule.Models.POCO.Request.Users;
using CompanyModule.Models.POCO.Response.Users;

namespace CompanyModule.Resources.AutoMapper
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<ApplicationUsersResponse, ApplicationUsersResponse>();
            CreateMap<ApplicationUserRequest, ApplicationUserRequest>();
        }
    }
}
