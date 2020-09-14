using Auth.DataLayer.Models;
using Auth.DataLayer.Models.Permissions;
using Auth.DataLayer.Models.Roles;
using Auth.DataLayer.Models.SystemModules;
using System;
using System.Collections.Generic;

namespace Auth.Services.PrimitivesServices.RoleServices
{
    public interface IRoleService
    {
        Role Add(string name, IEnumerable<Guid> systemModuleIds);
        Role Get(Guid id);
        Role Get(string name);
        IEnumerable<Role> GetAll();
        Role Update(Guid id, string name, IEnumerable<Guid> updatedSystemModuleIds);
        void Remove(Guid id);
        void RemoveRange(IEnumerable<Role> roles);
        IEnumerable<SystemModule> GetAllSystemModules(Guid id);
        IEnumerable<Permission> GetAllPermissions(Guid id);
        Permission AddPermission(Guid roleId, Guid workingEntityOperationId, Guid ruleId);
    }
}
