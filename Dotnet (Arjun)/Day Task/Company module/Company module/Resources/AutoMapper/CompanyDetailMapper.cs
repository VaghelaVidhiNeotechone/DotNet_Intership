using AutoMapper;
using Company_module.Models.DTO;
using Company_module.Models.POCO.Request.CompanyDetail;
using Company_module.Models.POCO.Response.CompanyDetail;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Company_module.Resources.AutoMapper
{
    public class CompanyDetailMapper : Profile
    {
        public CompanyDetailMapper()
        {
            CreateMap<CompanyDetailRequest, CompanyDetailEntity>();
            CreateMap<CompanyDetailEntity, CompanyDetailResponse>();
        }
    }

}
