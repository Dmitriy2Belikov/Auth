using Auth.DataLayer.Models;
using Auth.Web.Forms.Role;
using Auth.Web.Models.ViewModels.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Web.Builders.Roles
{
    public interface IRoleBuilder
    {
        Role BuildNew(RegisterRoleForm registerRoleForm);
        Role Edit(Guid id, EditRoleForm editRoleForm);
        RoleViewModel BuildViewModel(Guid id);
        RoleViewModel BuildViewModel(Role role);
    }
}
