using AutoMapper;
using CompanyModule.Models.DTO;
using CompanyModule.Models.POCO.Request.Currency;
using CompanyModule.Models.POCO.Response.Currency;

namespace CompanyModule.Resources.AutoMapper
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
