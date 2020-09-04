using Auth.DataLayer.Models;
using Auth.DataLayer.Repositories.PermissionRepos;
using Auth.DataLayer.Repositories.RoleSystemModuleRepos;
using Auth.DataLayer.Repositories.RoleRepos;
using Auth.DataLayer.Repositories.UserRoleRepos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Auth.Services.PrimitivesServices.RoleServices
{
    public class RoleService : IRoleService
    {
        private IRoleRepository _roleRepository;
        private IUserRoleRepository _userRoleRepository;

        private IRoleSystemModuleLinkRepository _roleSystemModuleLinkRepository;
        private IPermissionRepository _permissionRepository;

        public RoleService(
            IRoleRepository roleRepository, 
            IUserRoleRepository userRoleRepository, 
            IRoleSystemModuleLinkRepository roleModuleLinkRepository, 
            IPermissionRepository permissionRepository)
        {
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
            _roleSystemModuleLinkRepository = roleModuleLinkRepository;
            _permissionRepository = permissionRepository;
        }

        public void Add(Role role, IEnumerable<Guid> systemModuleIds, IEnumerable<Permission> permissions)
        {
            _roleRepository.Add(role);

            AssignSystemModules(role.Id, systemModuleIds);

            _permissionRepository.AddRange(permissions);
        }

        private void AssignSystemModules(Guid roleId, IEnumerable<Guid> systemModuleIds)
        {
            foreach (var systemModuleId in systemModuleIds)
            {
                var roleSystemModuleLink = new RoleSystemModuleLink()
                {
                    RoleId = roleId,
                    SystemModuleId = systemModuleId
                };

                _roleSystemModuleLinkRepository.Add(roleSystemModuleLink);
            }
        }

        public Role Get(Guid id)
        {
            var role = _roleRepository.Get(id);

            return role;
        }

        public Role Get(string name)
        {
            var role = _roleRepository.Get(name);

            return role;
        }

        public IEnumerable<Role> GetAll()
        {
            var roles = _roleRepository.GetAll();

            return roles;
        }

        public void Update(Role updatedRole, IEnumerable<Guid> updatedSystemModuleIds, IEnumerable<Permission> updatedPermissions)
        {
            var oldPermissions = _permissionRepository.GetAllPermissionsByRoleId(updatedRole.Id);
            _permissionRepository.RemoveRange(oldPermissions);
            _permissionRepository.UpdateRange(updatedPermissions);

            var oldSystemModuleLinks = _roleSystemModuleLinkRepository.GetAllByRoleId(updatedRole.Id);
            _roleSystemModuleLinkRepository.RemoveRange(oldSystemModuleLinks);
            AssignSystemModules(updatedRole.Id, updatedSystemModuleIds);

            _roleRepository.Update(updatedRole);
        }

        public void Remove(Guid id)
        {
            var role = _roleRepository.Get(id);

            var userRoles = _userRoleRepository.GetAllByRoleId(id);
            _userRoleRepository.RemoveRange(userRoles);

            var roleSystemModules = _roleSystemModuleLinkRepository.GetAllByRoleId(id);
            _roleSystemModuleLinkRepository.RemoveRange(roleSystemModules);

            var permissions = _permissionRepository.GetAllPermissionsByRoleId(id);
            _permissionRepository.RemoveRange(permissions);

            _roleRepository.Remove(role);
        }

        public void RemoveRange(IEnumerable<Role> roles)
        {
            var userRoles = roles.SelectMany(
                r => _userRoleRepository
                .GetAll()
                .Where(ur => ur.Role.Id == r.Id));

            _userRoleRepository.RemoveRange(userRoles);

            _roleRepository.RemoveRange(roles);
        }

        public IEnumerable<SystemModule> GetAllSystemModules(Guid id)
        {
            var systemModules = _roleSystemModuleLinkRepository.GetAllSystemModulesByRoleId(id);

            return systemModules;
        }

        public IEnumerable<Permission> GetAllPermissions(Guid id)
        {
            var permissions = _permissionRepository.GetAllPermissionsByRoleId(id);

            return permissions;
        }
    }
}
