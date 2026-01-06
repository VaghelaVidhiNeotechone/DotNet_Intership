using AutoMapper;
using CompanyModule.Models.DTO;
using CompanyModule.Models.POCO.Request.Country;
using CompanyModule.Models.POCO.Response.Country;

namespace CompanyModule.Resources.AutoMapper
{
    public class CountryMapper : Profile
    {
        public CountryMapper()
        {
            CreateMap<Country, CountryResponse>();
            CreateMap<CountryRequest, Country>();
        }
    }
}
