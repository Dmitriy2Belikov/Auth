using Auth.DataLayer.Models;
using Auth.DataLayer.Repositories.ModelRepos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.Repositories.PermissionRepos
{
    public interface IPermissionRepository : IModelRepository<Permission>
    {
        IEnumerable<Permission> GetAllPermissionsByRoleId(Guid roleId);
    }
}
