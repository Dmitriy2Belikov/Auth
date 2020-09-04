using Auth.Web.Models.Forms.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Web.Forms.Role
{
    public class RegisterRoleForm
    {
        public string Name { get; set; }
        public List<Guid> SystemModuleIds { get; set; }
        public List<RegisterPermissionForm> Permissions { get; set; }
    }
}
