using CompanyModule.Interface.Services.CompanyDetail;
using CompanyModule.Interface.Services.Country;
using CompanyModule.Interface.Services.Currency;
using CompanyModule.Services.CompanyDetail;
using CompanyModule.Services.Country;
using CompanyModule.Services.Currency;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyModule.Configuration.DI
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddServiceConfiguration(
            this IServiceCollection services)
        {
            services.AddScoped<ICompanyDetailServices, CompanyDetailServices>();
            services.AddScoped<ICompanyAttachmentServices, CompanyAttachmentServices>();
            services.AddScoped<ICountryServices, CountryServices>();
            services.AddScoped<ICurrencyServices, CurrencyServices>();

            return services;
        }
    }
}
