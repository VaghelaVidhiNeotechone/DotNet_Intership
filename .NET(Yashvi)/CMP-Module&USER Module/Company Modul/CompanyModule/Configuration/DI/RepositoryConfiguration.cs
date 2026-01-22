using CompanyModule.Domain;
using CompanyModule.Interface.Repository;

namespace CompanyModule.Configuration.DI
{
    public static class RepositoryConfiguration
    {
        public static IServiceCollection AddRepositoryConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ICompanyDetailRepository, CompanyDetailRepository>();
            services.AddScoped<ICompanyAttachmentRepository, CompanyAttachmentRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICurrencyRepository, CurrencyRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserFileRepository, UserFileRepository>();

            return services;
        }
    }
}