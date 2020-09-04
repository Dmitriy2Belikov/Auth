using Auth.DataLayer.Models;
using Auth.Services;
using Auth.Services.PrimitivesServices.UserServices;
using Auth.Web.Forms.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Web.Models.Builders.Users
{
    public class UserBuilder : IUserBuilder
    {
        private IUserService _userService;

        public UserBuilder(IUserService userService)
        {
            _userService = userService;
        }

        public User BuildNew(Guid personId, RegisterUserForm registerUserForm)
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                PersonId = personId,
                Login = registerUserForm.Login,
                Password = Helpers.HashPassword(registerUserForm.Password),
                LastActionTime = null
            };

            return user;
        }
    }
}
