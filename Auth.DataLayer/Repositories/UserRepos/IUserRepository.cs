using Auth.DataLayer.Models;
using Auth.DataLayer.Models.Persons;
using Auth.DataLayer.Models.Roles;
using Auth.DataLayer.Models.Users;
using Auth.DataLayer.Repositories.ModelRepos;
using System;
using System.Collections.Generic;

namespace Auth.DataLayer.Repositories.UserRepos
{
    public interface IUserRepository : IModelRepository<User>
    {
        User Get(string login);
        IEnumerable<Role> GetUserRoles(Guid id);
        IEnumerable<string> GetAllLogins();
        Person GetPerson(Guid id);
    }
}
