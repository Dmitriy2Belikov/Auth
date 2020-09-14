using Auth.DataLayer.Models.Roles;
using Auth.Services.PrimitivesServices.RoleServices;
using Auth.Web.Models.ModelBuilders.Permissions;
using Auth.Web.Models.ModelBuilders.SystemModules;
using Auth.Web.Models.ViewModels.Roles;
using System.Linq;

namespace Auth.Web.Models.ModelBuilders.Roles
{
    public class RoleModelBuilder : IRoleModelBuilder
    {
        private IRoleService _roleService;

        private IPermissionModelBuilder _permissionModelBuilder;
        private ISystemModuleModelBuilder _systemModuleModelBuilder;

        public RoleModelBuilder(
            IRoleService roleService, 
            IPermissionModelBuilder prmissionModelBuilder,
            ISystemModuleModelBuilder systemModuleModelBuilder)
        {
            _roleService = roleService;
            _permissionModelBuilder = prmissionModelBuilder;
            _systemModuleModelBuilder = systemModuleModelBuilder;
        }

        public RoleViewModel BuildNew(Role role)
        {
            var permissions = _roleService.GetAllPermissions(role.Id);
            var systemModules = _roleService.GetAllSystemModules(role.Id);

            var permissionViewModels = permissions.Select(p => _permissionModelBuilder.BuildNew(p)).ToList();
            var systemModuleViewModels = systemModules.Select(s => _systemModuleModelBuilder.BuildNew(s)).ToList();

            var roleViewModel = new RoleViewModel()
            {
                Id = role.Id,
                Name = role.Name,
                Permissions = permissionViewModels,
                SystemModules = systemModuleViewModels
            };

            return roleViewModel;
        }
    }
}
