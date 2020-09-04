using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.DataLayer.Models
{
    public class WorkingEntityOperation
    {
        public Guid Id { get; set; }
        public Guid SystemModuleId { get; set; }
        public Guid WorkingEntityId { get; set; }
        public string Title { get; set; }

        [ForeignKey("SystemModuleId")]
        public SystemModule SystemModule { get; set; }

        [ForeignKey("WorkingEntityId")]
        public WorkingEntity WorkingEntity { get; set; }
    }
}
