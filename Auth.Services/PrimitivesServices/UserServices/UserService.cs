using Auth.DataLayer.Models;
using Auth.DataLayer.Models.Roles;
using Auth.DataLayer.Models.UserRoleLinks;
using Auth.DataLayer.Models.Users;
using Auth.DataLayer.Repositories.RoleRepos;
using Auth.DataLayer.Repositories.UserRepos;
using Auth.DataLayer.Repositories.UserRoleRepos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Auth.Services.PrimitivesServices.UserServices
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IRoleRepository _roleRepository;
        private IUserRoleRepository _userRoleRepository;

        private IUserFactory _userFactory;
        private IUserRoleLinkFactory _userRoleLinkFactory;

        public UserService(IUserRepository userRepository, 
            IUserRoleRepository userRoleRepository, 
            IRoleRepository roleRepository, 
            IUserFactory userFactory, 
            IUserRoleLinkFactory userRoleLinkFactory)
        {
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _roleRepository = roleRepository;
            _userFactory = userFactory;
            _userRoleLinkFactory = userRoleLinkFactory;
        }

        public User Add(Guid personId, string login, string password, IEnumerable<Role> roles)
        {
            var user = _userFactory.Create(personId, login, password);
            _userRepository.Add(user);

            var userRoles = roles.Select(r => _userRoleLinkFactory.Create(user.Id, r.Id));
            _userRoleRepository.AddRange(userRoles);

            return user;
        }

        public User Get(Guid id)
        {
            var user = _userRepository.Get(id);

            return user;
        }

        public User Get(string login)
        {
            var user = _userRepository.Get(login);

            return user;
        }

        public IEnumerable<User> GetAll()
        {
            var users = _userRepository.GetAll();

            return users;
        }

        public User Update(Guid id, string login, string password, IEnumerable<Role> roles)
        {
            var updatedUser = _userFactory.Edit(id, login, password);

            RemoveUserRoles(updatedUser.Id);

            _userRepository.Update(updatedUser);

            var userRoles = roles.Select(r => _userRoleLinkFactory.Create(updatedUser.Id, r.Id));
            _userRoleRepository.AddRange(userRoles);

            return updatedUser;
        }

        public void RemoveUserRoles(Guid id)
        {
            var userRoles = _userRoleRepository
                .GetAll()
                .Where(u => u.User.Id == id);

            _userRoleRepository.RemoveRange(userRoles);
        }

        public void Remove(Guid id)
        {
            var user = _userRepository.Get(id);

            var userRoles = _userRoleRepository
                .GetAll()
                .Where(u => u.User.Id == id);

            _userRoleRepository.RemoveRange(userRoles);

            _userRepository.Remove(user);
        }

        public void RemoveRange(IEnumerable<User> users)
        {
            var userRoles = users.SelectMany(
                u => _userRoleRepository
                .GetAll()
                .Where(ur => ur.User.Id == u.Id));

            _userRoleRepository.RemoveRange(userRoles);

            _userRepository.RemoveRange(users);
        }

        public IEnumerable<Role> GetUserRoles(Guid id)
        {
            var roles = _userRepository.GetUserRoles(id);

            return roles;
        }
    }
}
