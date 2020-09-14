using Auth.DataLayer.Constants;
using Auth.DataLayer.Models;
using Auth.DataLayer.Models.Permissions;
using Auth.DataLayer.Repositories.PermissionRepos;
using Auth.DataLayer.Repositories.UserRepos;
using Auth.DataLayer.Repositories.UserRoleRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Auth.Services.AccountServices.AccessServices
{
    public class AccessService : IAccessService
    {
        public IUserRepository _userRepository;
        public IUserRoleRepository _userRoleRepository;
        public IPermissionRepository _permissionRepository;

        public AccessService(
            IUserRepository userRepository, 
            IUserRoleRepository userRoleRepository, 
            IPermissionRepository permissionRepository)
        {
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _permissionRepository = permissionRepository;
        }

        public Permission GetPermission(Guid userId, Guid workingEntityOperationId)
        {
            var roles = _userRoleRepository.GetAllByUserId(userId);

            var permissions = roles.SelectMany(r => _permissionRepository.GetAllPermissionsByRoleId(r.RoleId));

            var mainPermission = permissions.FirstOrDefault(p => p.WorkingEntityOperationId == workingEntityOperationId);

            return mainPermission;
        }
    }
}
