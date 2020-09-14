using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.Models.UserRoleLinks
{
    public class UserRoleLinkFactory : IUserRoleLinkFactory
    {
        public UserRoleLink Create(Guid userId, Guid roleId)
        {
            var userRoleLink = new UserRoleLink()
            {
                UserId = userId,
                RoleId = roleId
            };

            return userRoleLink;
        }
    }
}
