using Auth.DataLayer.Models;
using System;
using System.Collections.Generic;

namespace Auth.Services.PrimitivesServices.UserServices
{
    public interface IUserService
    {
        void Add(User user, IEnumerable<Role> roles);
        User Get(Guid id);
        User Get(string login);
        IEnumerable<User> GetAll();
        void Update(User updatedUser, IEnumerable<Role> roles);
        void RemoveUserRoles(Guid id);
        void Remove(Guid id);
        void RemoveRange(IEnumerable<User> users);
        IEnumerable<Role> GetUserRoles(Guid id);
    }
}
