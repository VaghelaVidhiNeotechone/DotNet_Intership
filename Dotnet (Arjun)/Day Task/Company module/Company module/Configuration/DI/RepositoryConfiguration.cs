using Company_module.Domain;
using Company_module.Domain.Repository;
using Company_module.Interface.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Company_module.Configuration.DI
{
    public static class RepositoryConfiguration
    {
        public static IServiceCollection AddRepositoryConfiguration(
            this IServiceCollection services)
        {
            services.AddScoped<ICompanyDetailRepository, CompanyDetailRepository>();
            services.AddScoped<ICompanyAttachmentRepository, CompanyAttachmentRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICurrencyRepository, CurrencyRepository>();


            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
