using Company_module.Interface.Services.CompanyDetail;
using Company_module.Interface.Services.Country;
using Company_module.Interface.Services.Currency;
using Company_module.Services.CompanyDetail;
using Company_module.Services.Country;
using Company_module.Services.Currency;
using Microsoft.Extensions.DependencyInjection;

namespace Company_module.Configuration.DI
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
