using Auth.DataLayer.Models;
using Auth.Services.PrimitivesServices.RoleServices;
using Auth.Web.Forms.Role;
using Auth.Web.Models.Builders.Permissions;
using Auth.Web.Models.Builders.SystemModules;
using Auth.Web.Models.ViewModels.Roles;
using System;
using System.Linq;

namespace Auth.Web.Builders.Roles
{
    public class RoleBuilder : IRoleBuilder
    {
        private IRoleService _roleService;
        private ISystemModuleBuilder _systemModuleBuilder;
        private IPermissionBuilder _permissionBuilder;

        public RoleBuilder(IRoleService roleService, ISystemModuleBuilder systemModuleBuilder, IPermissionBuilder permissionBuilder)
        {
            _roleService = roleService;
            _systemModuleBuilder = systemModuleBuilder;
            _permissionBuilder = permissionBuilder;
        }

        public Role BuildNew(RegisterRoleForm registerRoleForm)
        {
            var role = new Role()
            {
                Id = Guid.NewGuid(),
                Name = registerRoleForm.Name
            };

            return role;
        }

        public Role Edit(Guid id, EditRoleForm editRoleForm)
        {
            var role = _roleService.Get(id);

            role.Name = editRoleForm.Name;

            return role;
        }

        public RoleViewModel BuildViewModel(Guid id)
        {
            var role = _roleService.Get(id);

            var systemModules = _roleService
                .GetAllSystemModules(id)
                .Select(s => _systemModuleBuilder.BuildViewModel(s))
                .ToList();

            var permissions = _roleService
                .GetAllPermissions(id)
                .Select(p => _permissionBuilder.BuildViewModel(p))
                .ToList();

            var roleViewModel = new RoleViewModel()
            {
                Id = role.Id,
                Name = role.Name,
                SystemModules = systemModules,
                Permissions = permissions
            };

            return roleViewModel;
        }

        public RoleViewModel BuildViewModel(Role role)
        {
            var systemModules = _roleService
                .GetAllSystemModules(role.Id)
                .Select(s => _systemModuleBuilder.BuildViewModel(s))
                .ToList();

            var permissions = _roleService
                .GetAllPermissions(role.Id)
                .Select(p => _permissionBuilder.BuildViewModel(p))
                .ToList();

            var roleViewModel = new RoleViewModel()
            {
                Id = role.Id,
                Name = role.Name,
                SystemModules = systemModules,
                Permissions = permissions
            };

            return roleViewModel;
        }
    }
}
