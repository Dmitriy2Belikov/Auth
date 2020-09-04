using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Web.Models.Forms.Permissions
{
    public class EditPermissionForm
    {
        public Guid WorkingEntityOperationId { get; set; }
        public Guid RuleId { get; set; }
    }
}
