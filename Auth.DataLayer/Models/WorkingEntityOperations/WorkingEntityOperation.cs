using Auth.DataLayer.Models.SystemModules;
using Auth.DataLayer.Models.WorkingEntities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auth.DataLayer.Models.WorkingEntityOperations
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
