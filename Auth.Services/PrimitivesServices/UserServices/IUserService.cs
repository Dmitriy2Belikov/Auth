using Auth.DataLayer.Models;
using Auth.DataLayer.Models.Roles;
using Auth.DataLayer.Models.Users;
using System;
using System.Collections.Generic;

namespace Auth.Services.PrimitivesServices.UserServices
{
    public interface IUserService
    {
        User Add(Guid personId, string login, string password, IEnumerable<Role> roles);
        User Get(Guid id);
        User Get(string login);
        IEnumerable<User> GetAll();
        User Update(Guid id, string login, string password, IEnumerable<Role> roles);
        void RemoveUserRoles(Guid id);
        void Remove(Guid id);
        void RemoveRange(IEnumerable<User> users);
        IEnumerable<Role> GetUserRoles(Guid id);
    }
}
