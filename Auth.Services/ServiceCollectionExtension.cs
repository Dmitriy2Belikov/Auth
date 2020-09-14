using Auth.Services.AccountServices;
using Auth.Services.AccountServices.AccessServices;
using Auth.Services.AccountServices.TokenAuthenticateServices;
using Auth.Services.AccountServices.ValidateServices;
using Auth.Services.CookieServices.CookieServices;
using Auth.Services.PrimitivesServices.OrganizationServices;
using Auth.Services.PrimitivesServices.OrganizationTypeServices;
using Auth.Services.PrimitivesServices.PersonServices;
using Auth.Services.PrimitivesServices.RoleServices;
using Auth.Services.PrimitivesServices.UserServices;
using Auth.Services.SeedServices;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Services
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IOrganizationService, OrganizationService>();
            services.AddTransient<IOrganizationTypeService, OrganizationTypeService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IPersonService, PersonService>();

            services.AddTransient<ICookieService, CookieService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IAccessService, AccessService>();
            services.AddTransient<IValidateService, ValidateService>();

            services.AddTransient<ISeedService, SeedService>();

            return services;
        }
    }
}
