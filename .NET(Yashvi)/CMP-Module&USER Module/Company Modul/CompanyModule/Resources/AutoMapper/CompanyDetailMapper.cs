using AutoMapper;
using CompanyModule.Models.DTO;
using CompanyModule.Models.POCO.Request.CompanyDetail;
using CompanyModule.Models.POCO.Response.CompanyDetail;

namespace CompanyModule.Resources.AutoMapper
{
    public class CompanyDetailMapper : Profile
    {
        public CompanyDetailMapper()
        {
            CreateMap<CompanyDetailRequest, CompanyDetailEntity>()
                .ForMember(dest => dest.companyid, opt => opt.Ignore())
                .ForMember(dest => dest.countryid, opt => opt.Ignore())
                .ForMember(dest => dest.currencyid, opt => opt.Ignore());

            CreateMap<CompanyDetailEntity, CompanyDetailResponse>();
        }
    }
}
