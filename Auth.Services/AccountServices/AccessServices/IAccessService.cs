using Auth.DataLayer.Models;
using Auth.DataLayer.Models.Permissions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.Services.AccountServices.AccessServices
{
    public interface IAccessService
    {
        Permission GetPermission(Guid userId, Guid workingEntityOperationId);
    }
}
