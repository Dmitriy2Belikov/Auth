using Auth.DataLayer.Models;
using Auth.Web.Models.ViewModels.Pemissions;
using Auth.Web.Models.ViewModels.SystemModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Web.Models.ViewModels.Roles
{
    public class RoleViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<SystemModuleViewModel> SystemModules { get; set; }
        public List<PermissionViewModel> Permissions { get; set; }
    }
}
