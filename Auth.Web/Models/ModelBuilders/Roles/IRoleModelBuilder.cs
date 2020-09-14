using Auth.DataLayer.Models.Roles;
using Auth.Web.Models.ViewModels.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Web.Models.ModelBuilders.Roles
{
    public interface IRoleModelBuilder
    {
        RoleViewModel BuildNew(Role role);
    }
}
