using Auth.DataLayer.Models.OrganizationDistrictLinks;
using Auth.DataLayer.Models.OrganizationRequisites;
using Auth.DataLayer.Models.Organizations;
using Auth.DataLayer.Models.OrganizationTypes;
using Auth.DataLayer.Models.Permissions;
using Auth.DataLayer.Models.Persons;
using Auth.DataLayer.Models.RefreshSessions;
using Auth.DataLayer.Models.Roles;
using Auth.DataLayer.Models.RoleSystemModuleLinks;
using Auth.DataLayer.Models.UserRoleLinks;
using Auth.DataLayer.Models.Users;
using Auth.DataLayer.Models.WorkingEntities;
using Auth.DataLayer.Models.WorkingEntityOperations;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Auth.DataLayer
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddFactories(this IServiceCollection services)
        {
            services.AddTransient<IOrganizationDistrictLinkFactory, OrganizationDistrictLinkFactory>();
            services.AddTransient<IOrganizationRequisiteFactory, OrganizationRequisiteFactory>();
            services.AddTransient<IOrganizationFactory, OrganizationFactory>();
            services.AddTransient<IOrganizationTypeFactory, OrganizationTypeFactory>();
            services.AddTransient<IPermissionFactory, PermissionFactory>();
            services.AddTransient<IPersonFactory, PersonFactory>();
            services.AddTransient<IRefreshSessionFactory, RefreshSessionFactory>();
            services.AddTransient<IRoleFactory, RoleFactory>();
            services.AddTransient<IRoleSystemModuleLinkFactory, RoleSystemModuleLinkFactory>();
            services.AddTransient<IUserRoleLinkFactory, UserRoleLinkFactory>();
            services.AddTransient<IUserFactory, UserFactory>();
            services.AddTransient<IWorkingEntityOperationFactory, WorkingEntityOperationFactory>();

            return services;
        }
    }
}
