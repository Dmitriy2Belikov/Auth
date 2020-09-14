using Auth.DataLayer.Models;
using Auth.DataLayer.Models.UserRoleLinks;
using Auth.DataLayer.Repositories.ModelRepos;
using System;
using System.Collections.Generic;

namespace Auth.DataLayer.Repositories.UserRoleRepos
{
    public interface IUserRoleRepository : IModelRepository<UserRoleLink>
    {
        IEnumerable<UserRoleLink> GetAllByRoleId(Guid roleId);
        IEnumerable<UserRoleLink> GetAllByUserId(Guid userId);
    }
}
