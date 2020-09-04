using Auth.DataLayer.Models;
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

        public UserService(IUserRepository userRepository, IUserRoleRepository userRoleRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _roleRepository = roleRepository;
        }

        public void Add(User user, IEnumerable<Role> roles)
        {
            _userRepository.Add(user);

            foreach (var role in roles)
            {
                var userRole = new UserRoleLink()
                {
                    UserId = user.Id,
                    RoleId = role.Id
                };

                _userRoleRepository.Add(userRole);
            }
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

        public void Update(User updatedUser, IEnumerable<Role> roles)
        {
            RemoveUserRoles(updatedUser.Id);

            _userRepository.Update(updatedUser);

            foreach (var role in roles)
            {
                var userRole = new UserRoleLink()
                {
                    Role = role,
                    User = updatedUser
                };

                _userRoleRepository.Add(userRole);
            }
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
