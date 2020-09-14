using Auth.Web.Models.ModelBuilders.OrganizationRequisites;
using Auth.Web.Models.ModelBuilders.Organizations;
using Auth.Web.Models.ModelBuilders.OrganizationTypes;
using Auth.Web.Models.ModelBuilders.Permissions;
using Auth.Web.Models.ModelBuilders.Persons;
using Auth.Web.Models.ModelBuilders.Roles;
using Auth.Web.Models.ModelBuilders.Rules;
using Auth.Web.Models.ModelBuilders.SystemModules;
using Auth.Web.Models.ModelBuilders.Users;
using Auth.Web.Models.ModelBuilders.WorkingEntityOperations;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Web.Builders
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddBuilders(this IServiceCollection services)
        {
            services.AddTransient<IOrganizationRequisiteModelBuilder, OrganizationRequisiteModelBuilder>();
            services.AddTransient<IOrganizationModelBuilder, OrganizationModelBuilder>();
            services.AddTransient<IOrganizationTypeModelBuilder, OrganizationTypeModelBuilder>();
            services.AddTransient<IPermissionModelBuilder, PermissionModelBuilder>();
            services.AddTransient<IPersonModelBuilder, PersonModelBuilder>();
            services.AddTransient<IRoleModelBuilder, RoleModelBuilder>();
            services.AddTransient<IRuleModelBuilder, RuleModelBuilder>();
            services.AddTransient<ISystemModuleModelBuilder, SystemModuleModelBuilder>();
            services.AddTransient<IUserModelBuilder, UserModelBuilder>();
            services.AddTransient<IWorkingEntityOperationModelBuilder, WorkingEntityOperationModelBuilder>();

            return services;
        }
    }
}
