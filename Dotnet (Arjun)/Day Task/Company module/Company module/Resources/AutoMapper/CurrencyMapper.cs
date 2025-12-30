using AutoMapper;
using Company_module.Models.DTO;
using Company_module.Models.POCO.Request.Currency;
using Company_module.Models.POCO.Response.Currency;

namespace Company_module.Resources.AutoMapper
{
    public class CurrencyMapper : Profile
    {
        public CurrencyMapper() 
        {
            CreateMap<Currency, CurrencyResponse>();
            CreateMap<CurrencyRequest, Currency>();
        }
    }
}
