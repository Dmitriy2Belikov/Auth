using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.Models.UserRoleLinks
{
    public interface IUserRoleLinkFactory
    {
        UserRoleLink Create(Guid userId, Guid roleId);
    }
}
