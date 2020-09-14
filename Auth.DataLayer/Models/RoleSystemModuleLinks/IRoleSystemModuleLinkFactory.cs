using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.Models.RoleSystemModuleLinks
{
    public interface IRoleSystemModuleLinkFactory
    {
        RoleSystemModuleLink Create(Guid roleId, Guid systemModuleId);
    }
}
