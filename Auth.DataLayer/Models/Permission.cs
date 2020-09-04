using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.DataLayer.Models
{
    public class Permission
    {
        [Key, Column(Order = 1)]
        public Guid RoleId { get; set; }

        [Key, Column(Order = 2)]
        public Guid WorkingEntityOperationId { get; set; }

        public Guid RuleId { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }

        [ForeignKey("WorkingEntityOperationId")]
        public WorkingEntityOperation WorkingEntityOperation { get; set; }

        [ForeignKey("RuleId")]
        public Rule Rule { get; set; }
    }
}
