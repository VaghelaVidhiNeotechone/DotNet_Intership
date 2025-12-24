using AutoMapper;
using Company_module.Models.DTO;
using Company_module.Models.POCO.Request.Country;
using Company_module.Models.POCO.Response.Country;

namespace Company_module.Resources.AutoMapper
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
