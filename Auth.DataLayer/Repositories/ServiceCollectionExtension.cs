using Auth.DataLayer.Repositories.OrganizationDistrictLinkRepos;
using Auth.DataLayer.Repositories.OrganizationRepos;
using Auth.DataLayer.Repositories.OrganizationRequisitesRepos;
using Auth.DataLayer.Repositories.OrganizationTypeRepos;
using Auth.DataLayer.Repositories.PermissionRepos;
using Auth.DataLayer.Repositories.PersonRepos;
using Auth.DataLayer.Repositories.RoleSystemModuleRepos;
using Auth.DataLayer.Repositories.RoleRepos;
using Auth.DataLayer.Repositories.UserRepos;
using Auth.DataLayer.Repositories.UserRoleRepos;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Auth.DataLayer.Repositories.RefreshSessionRepos;

namespace Auth.DataLayer.Repositories
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IOrganizationDistrictLinkRepository, OrganizationDistrictLinkRepository>();
            services.AddTransient<IOrganizationRepository, OrganizationRepository>();
            services.AddTransient<IOrganizationRequisitesRepository, OrganizationRequisitesRepository>();
            services.AddTransient<IOrganizationTypeRepository, OrganizationTypeRepository>();
            services.AddTransient<IPermissionRepository, PermissionRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IRoleSystemModuleLinkRepository, RoleSystemModuleLinkRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserRoleRepository, UserRoleRepository>();
            services.AddTransient<IRefreshSessionRepository, RefreshSessionRepository>();


            return services;
        }
    }
}
