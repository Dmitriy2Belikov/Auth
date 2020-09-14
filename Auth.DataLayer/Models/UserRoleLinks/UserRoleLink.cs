using Auth.DataLayer.Models.Roles;
using Auth.DataLayer.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.DataLayer.Models.UserRoleLinks
{
    public class UserRoleLink
    {
        [Key, Column(Order = 1)]
        public Guid UserId { get; set; }

        [Key, Column(Order = 2)]
        public Guid RoleId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }
    }
}
