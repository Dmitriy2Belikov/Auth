using Auth.DataLayer.Models.Permissions;
using Auth.Web.Models.ViewModels.Pemissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Web.Models.ModelBuilders.Permissions
{
    public interface IPermissionModelBuilder
    {
        PermissionViewModel BuildNew(Permission permission);
    }
}
