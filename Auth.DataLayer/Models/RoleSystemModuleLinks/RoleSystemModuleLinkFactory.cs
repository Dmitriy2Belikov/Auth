using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.Models.RoleSystemModuleLinks
{
    public class RoleSystemModuleLinkFactory : IRoleSystemModuleLinkFactory
    {
        public RoleSystemModuleLink Create(Guid roleId, Guid systemModuleId)
        {
            var roleSystemModule = new RoleSystemModuleLink()
            {
                RoleId = roleId,
                SystemModuleId = systemModuleId
            };

            return roleSystemModule;
        }
    }
}
