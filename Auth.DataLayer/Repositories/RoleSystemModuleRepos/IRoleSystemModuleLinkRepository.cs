using Auth.DataLayer.Models;
using Auth.DataLayer.Models.RoleSystemModuleLinks;
using Auth.DataLayer.Models.SystemModules;
using Auth.DataLayer.Repositories.ModelRepos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.Repositories.RoleSystemModuleRepos
{
    public interface IRoleSystemModuleLinkRepository : IModelRepository<RoleSystemModuleLink>
    {
        SystemModule GetSystemModule(Guid roleId, Guid systemModuleId);
        IEnumerable<SystemModule> GetAllSystemModulesByRoleId(Guid roleId);
        IEnumerable<RoleSystemModuleLink> GetAllByRoleId(Guid roleId);
    }
}
