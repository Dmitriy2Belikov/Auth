using Auth.DataLayer.Models;
using Auth.DataLayer.Repositories.RefreshSessionRepos;
using Auth.Services.AccountServices.BrowserDataModel;
using Auth.Services.AccountServices.TokenAuthenticateServices;
using Auth.Services.PrimitivesServices.PersonServices;
using Auth.Services.PrimitivesServices.RoleServices;
using Auth.Services.PrimitivesServices.UserServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Auth.Services.AccountServices
{
    public class AccountService : IAccountService
    {
        private IUserService _userService;
        private IRoleService _roleService;
        private ITokenService _tokenService;
        private IRefreshSessionRepository _refreshSessionRepository;
        private IPersonRepository _personRepository;

        public AccountService(
            IUserService userService,
            IRoleService roleService,
            IRefreshSessionRepository refreshSessionRepository, 
            ITokenService tokenService, 
            IPersonRepository personRepository)
        {
            _userService = userService;
            _roleService = roleService;
            _refreshSessionRepository = refreshSessionRepository;
            _tokenService = tokenService;
            _personRepository = personRepository;
        }

        public (string AccessToken, string RefreshToken) Login(string login, string password, BrowserData browserData)
        {
            var user = _userService.Get(login);

            var identity = GetIdentity(user);

            var accessToken = _tokenService.BuildNewAccessToken(identity);

            var refreshToken = _tokenService.BuildNewRefreshToken();

            var oldRefreshSession = _refreshSessionRepository.Get(user.Id, browserData.IP, browserData.UserAgent);

            if (oldRefreshSession != null)
            {
                _refreshSessionRepository.Remove(oldRefreshSession.Id);
            }

            var refreshSession = _tokenService.BuildNewRefreshSession(user.Id, browserData.IP, browserData.UserAgent, refreshToken);
            _refreshSessionRepository.Add(refreshSession);

            return (accessToken, refreshToken);
        }

        public ClaimsIdentity GetIdentity(User user)
        {
            if (user != null)
            {
                var roles = _userService.GetUserRoles(user.Id);

                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login)
                };

                var roleClaims = roles.Select(r => new Claim(ClaimsIdentity.DefaultRoleClaimType, r.Name));

                claims.AddRange(roleClaims);

                var identity = new ClaimsIdentity(
                    claims, 
                    "Token", 
                    ClaimsIdentity.DefaultNameClaimType, 
                    ClaimsIdentity.DefaultRoleClaimType);

                return identity;
            }

            return null;
        }

        public User Register(User user, Person person, IEnumerable<Role> roles)
        {
            var exists = _userService.Get(user.Login);

            if (exists == null)
            {
                _personRepository.Add(person);

                _userService.Add(user, roles);

                return user;
            }

            return null;
        }

        //public bool Verify(User user, string password)
        //{
        //    if (user != null)
        //    {
        //        return Helpers.Verify(password, user.Password);
        //    }

        //    return false;
        //}
    }
}
