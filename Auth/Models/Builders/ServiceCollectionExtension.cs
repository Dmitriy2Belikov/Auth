using Auth.Web.Builders.OrganizationRequisites;
using Auth.Web.Builders.Organizations;
using Auth.Web.Builders.OrganizationTypes;
using Auth.Web.Builders.Roles;
using Auth.Web.Models.Builders.WorkingEntityOperations;
using Auth.Web.Models.Builders.Permissions;
using Auth.Web.Models.Builders.Rules;
using Auth.Web.Models.Builders.SystemModules;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth.Web.Models.Builders.Users;
using Auth.Web.Models.Builders.Persons;

namespace Auth.Web.Builders
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddBuilders(this IServiceCollection services)
        {
            services.AddTransient<IOrganizationBuilder, OrganizationBuilder>();
            services.AddTransient<IOrganizationTypeBuilder, OrganizationTypeBuilder>();
            services.AddTransient<IOrganizationRequisitesBuilder, OrganizationRequisitesBuilder>();
            services.AddTransient<IWorkingEntityOperationBuilder, WorkingEntityOperationBuilder>();
            services.AddTransient<IPermissionBuilder, PermissionBuilder>();
            services.AddTransient<IRoleBuilder, RoleBuilder>();
            services.AddTransient<IRuleBuilder, RuleBuilder>();
            services.AddTransient<ISystemModuleBuilder, SystemModuleBuilder>();
            services.AddTransient<IPersonBuilder, PersonBuilder>();
            services.AddTransient<IUserBuilder, UserBuilder>();

            return services;
        }
    }
}
