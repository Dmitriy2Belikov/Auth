using Auth.DataLayer.Models;
using Auth.DataLayer.Repositories.PermissionRepos;
using Auth.DataLayer.Repositories.RoleSystemModuleRepos;
using Auth.DataLayer.Repositories.RoleRepos;
using Auth.DataLayer.Repositories.UserRoleRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using Auth.DataLayer.Models.Roles;
using Auth.DataLayer.Models.RoleSystemModuleLinks;
using Auth.DataLayer.Models.Permissions;
using Auth.DataLayer.Models.SystemModules;

namespace Auth.Services.PrimitivesServices.RoleServices
{
    public class RoleService : IRoleService
    {
        private IRoleRepository _roleRepository;
        private IUserRoleRepository _userRoleRepository;
        private IRoleSystemModuleLinkRepository _roleSystemModuleLinkRepository;
        private IPermissionRepository _permissionRepository;

        private IRoleFactory _roleFactory;
        private IPermissionFactory _permissionFactory;

        public RoleService(
            IRoleRepository roleRepository,
            IUserRoleRepository userRoleRepository,
            IRoleSystemModuleLinkRepository roleModuleLinkRepository,
            IPermissionRepository permissionRepository,
            IRoleSystemModuleLinkRepository roleSystemModuleLinkRepository,
            IRoleFactory roleFactory, 
            IPermissionFactory permissionFactory)
        {
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
            _roleSystemModuleLinkRepository = roleModuleLinkRepository;
            _permissionRepository = permissionRepository;
            _roleSystemModuleLinkRepository = roleSystemModuleLinkRepository;
            _roleFactory = roleFactory;
            _permissionFactory = permissionFactory;
        }

        public Role Add(string name, IEnumerable<Guid> systemModuleIds)
        {
            var role = _roleFactory.Create(name);

            _roleRepository.Add(role);

            AssignSystemModules(role.Id, systemModuleIds);

            return role;
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

        public Role Update(Guid id, string name, IEnumerable<Guid> updatedSystemModuleIds)
        {
            var updatedRole = _roleFactory.Edit(id, name);

            var oldPermissions = _permissionRepository.GetAllPermissionsByRoleId(id);
            _permissionRepository.RemoveRange(oldPermissions);

            var oldSystemModuleLinks = _roleSystemModuleLinkRepository.GetAllByRoleId(updatedRole.Id);
            _roleSystemModuleLinkRepository.RemoveRange(oldSystemModuleLinks);
            AssignSystemModules(updatedRole.Id, updatedSystemModuleIds);

            _roleRepository.Update(updatedRole);

            return updatedRole;
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

        public Permission AddPermission(Guid roleId, Guid workingEntityOperationId, Guid ruleId)
        {
            var permission = _permissionFactory.Create(roleId, workingEntityOperationId, ruleId);

            _permissionRepository.Add(permission);

            return permission;
        }
    }
}
