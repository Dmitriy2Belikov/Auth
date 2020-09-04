using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Web.Models.ViewModels.WorkingEntityOperations
{
    public class WorkingEntityOperationViewModel
    {
        public Guid Id { get; set; }
        public Guid SystemModuleId { get; set; }
        public Guid WorkingEntityId { get; set; }
        public string Title { get; set; }
    }
}
