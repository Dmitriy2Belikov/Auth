using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.Models.Permissions
{
    public interface IPermissionFactory
    {
        Permission Create(Guid roleId, Guid workingEntityOperationId, Guid ruleId);
    }
}
