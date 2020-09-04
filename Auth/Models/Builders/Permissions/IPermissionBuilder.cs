using Auth.DataLayer.Models;
using Auth.Web.Models.Forms.Permissions;
using Auth.Web.Models.ViewModels.Pemissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Web.Models.Builders.Permissions
{
    public interface IPermissionBuilder
    {
        Permission BuildNew(Role role, RegisterPermissionForm registerPermissionForm);
        Permission BuildNew(Role role, EditPermissionForm editPermissionForm);
        PermissionViewModel BuildViewModel(Permission permission);
    }
}
