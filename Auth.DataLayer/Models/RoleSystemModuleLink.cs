using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auth.DataLayer.Models
{
    public class RoleSystemModuleLink
    {
        [Key, Column(Order = 1)]
        public Guid RoleId { get; set; }

        [Key, Column(Order = 2)]
        public Guid SystemModuleId { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }

        [ForeignKey("SystemModuleId")]
        public SystemModule SystemModule { get; set; }
    }
}
