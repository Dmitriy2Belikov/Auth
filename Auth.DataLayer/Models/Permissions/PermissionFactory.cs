using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.Models.Permissions
{
    public class PermissionFactory : IPermissionFactory
    {
        public Permission Create(Guid roleId, Guid workingEntityOperationId, Guid ruleId)
        {
            var permission = new Permission()
            {
                RoleId = roleId,
                WorkingEntityOperationId = workingEntityOperationId,
                RuleId = ruleId
            };

            return permission;
        }
    }
}
