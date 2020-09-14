using Auth.DataLayer.Repositories.UserRepos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.Models.Users
{
    public class UserFactory : IUserFactory
    {
        private IUserRepository _userReposiotry;

        public UserFactory(IUserRepository userReposiotry)
        {
            _userReposiotry = userReposiotry;
        }

        public User Create(Guid personId, string login, string password)
        {
            var user = new User()
            {
                Id = personId,
                Login = login,
                Password = Helpers.HashPassword(password),
                LastActionTime = null
            };

            return user;
        }

        public User Edit(Guid id, string login, string password)
        {
            var user = _userReposiotry.Get(id);

            user.Login = login;
            user.Password = Helpers.HashPassword(password);

            return user;
        }
    }
}
