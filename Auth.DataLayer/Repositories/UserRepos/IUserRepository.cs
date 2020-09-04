using Auth.DataLayer.Models;
using Auth.DataLayer.Repositories.ModelRepos;
using System;
using System.Collections.Generic;

namespace Auth.DataLayer.Repositories.UserRepos
{
    public interface IUserRepository : IModelRepository<User>
    {
        User Get(string login);
        IEnumerable<Role> GetUserRoles(Guid id);
    }
}
