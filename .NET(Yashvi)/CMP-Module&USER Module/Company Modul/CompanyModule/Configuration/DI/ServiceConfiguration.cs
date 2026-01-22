using CompanyModule.Interface.Services;
using CompanyModule.Interface.Services.CompanyDetail;
using CompanyModule.Interface.Services.Country;
using CompanyModule.Interface.Services.Currency;
using CompanyModule.Interface.Services.User;
using CompanyModule.Interface.Services.UserRole;
using CompanyModule.Services;

namespace CompanyModule.Configuration.DI
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddServiceConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ICompanyDetailServices, CompanyDetailServices>();
            services.AddScoped<ICompanyAttachmentServices, CompanyAttachmentServices>();
            services.AddScoped<ICountryServices, CountryServices>();
            services.AddScoped<ICurrencyServices, CurrencyServices>();
            services.AddScoped<IUserRoleService, UserRoleService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserFileService, UserFileService>();

            return services;
        }
    }
}