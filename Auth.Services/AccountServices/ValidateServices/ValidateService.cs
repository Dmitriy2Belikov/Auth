using Auth.DataLayer.Repositories.UserRepos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.Services.AccountServices.ValidateServices
{
    public class ValidateService : IValidateService
    {
        private IUserRepository _userReposiotry;

        public ValidateService(IUserRepository userReposiotry)
        {
            _userReposiotry = userReposiotry;
        }

        public bool IsExistLogin(string login)
        {
            var userLogins = _userReposiotry.GetAllLogins();

            foreach (var userLogin in userLogins)
            {
                if (login.Equals(userLogin))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
