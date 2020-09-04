using Auth.DataLayer.Models;
using System;
using System.Collections.Generic;

namespace Auth.Services.PrimitivesServices.RoleServices
{
    public interface IRoleService
    {
        void Add(Role role, IEnumerable<Guid> systemModuleIds, IEnumerable<Permission> permissions);
        Role Get(Guid id);
        Role Get(string name);
        IEnumerable<Role> GetAll();
        void Update(Role updatedRole, IEnumerable<Guid> updatedSystemModuleIds, IEnumerable<Permission> updatedPermissions);
        void Remove(Guid id);
        void RemoveRange(IEnumerable<Role> roles);
        IEnumerable<SystemModule> GetAllSystemModules(Guid id);
        IEnumerable<Permission> GetAllPermissions(Guid id);
    }
}
