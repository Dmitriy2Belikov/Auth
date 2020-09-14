using Auth.Web.Models.ViewModels.WorkingEntityOperations;
using Auth.Web.Models.ViewModels.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Web.Models.ViewModels.Pemissions
{
    public class PermissionViewModel
    {
        public WorkingEntityOperationViewModel WorkingEntityOperation { get; set; }
        public RuleViewModel Rule { get; set; }
    }
}
