using Auth.DataLayer;
using Auth.DataLayer.Enums;
using Auth.DataLayer.Models.Persons;
using Auth.DataLayer.Models.RefreshSessions;
using Auth.DataLayer.Models.Roles;
using Auth.DataLayer.Models.Users;
using Auth.DataLayer.Repositories.RefreshSessionRepos;
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
        private IPersonService _personService;

        private IRefreshSessionFactory _refreshSessionFactory;

        public AccountService(
            IUserService userService,
            IRoleService roleService,
            IRefreshSessionRepository refreshSessionRepository,
            ITokenService tokenService,
            IPersonService personRepository,
            IRefreshSessionFactory refreshSessionFactory)
        {
            _userService = userService;
            _roleService = roleService;
            _refreshSessionRepository = refreshSessionRepository;
            _tokenService = tokenService;
            _personService = personRepository;
            _refreshSessionFactory = refreshSessionFactory;
        }

        public (string AccessToken, string RefreshToken) GetNewTokenPair(User user, ClaimsIdentity identity, string refresh)
        {
            if (_tokenService.VerifyRefreshToken(user, refresh))
            {
                var tokens = GetTokenPair(user, identity);

                return tokens;
            }

            return (null, null);
        }

        public (string AccessToken, string RefreshToken) Login(User user, ClaimsIdentity identity)
        {
            var tokens = GetTokenPair(user, identity);

            return tokens;
        }

        private (string AccessToken, string RefreshToken) GetTokenPair(User user, ClaimsIdentity identity)
        {
            var accessToken = _tokenService.BuildNewAccessToken(identity);

            var refreshToken = _tokenService.BuildNewRefreshToken();

            UpdateRefreshSession(user.Id, refreshToken);

            return (accessToken, refreshToken);
        }

        private void UpdateRefreshSession(Guid userId, string refreshToken)
        {
            var oldRefreshSession = _refreshSessionRepository.GetByUserId(userId);

            if (oldRefreshSession != null)
            {
                _refreshSessionRepository.Remove(oldRefreshSession.Id);
            }

            var refreshSession = _tokenService.BuildNewRefreshSession(userId, refreshToken);
            _refreshSessionRepository.Add(refreshSession);
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

        public User Register(string login,
            string password,
            string firstName,
            string lastName,
            string surName,
            Genders gender, DateTime? birthDate,
            string snils,
            string email,
            string phone,
            string registrationAddress,
            string factAddress,
            string otherPhones,
            IEnumerable<Role> roles)
        {
            var person = _personService.Add(firstName, lastName, surName, gender, birthDate, snils, email, phone, registrationAddress, factAddress, otherPhones);

            var user = _userService.Add(person.Id, login, password, roles);

            return user;
        }

        public bool Verify(User user, string password)
        {
            if (user != null)
            {
                return Helpers.Verify(password, user.Password);
            }

            return false;
        }

        public void RemoveProfile(Guid userId)
        {
            var user = _userService.Get(userId);

            _personService.Remove(user.Id);

            _userService.Remove(user.Id);
        }

        public User EditProfile(Guid id,
            string login,
            string password,
            IEnumerable<Role> roles,
            string firstName,
            string lastName,
            string surName,
            Genders gender,
            DateTime? birthDate,
            string snils,
            string email,
            string phone,
            string registrationAddress,
            string factAddress,
            string otherPhones)
        {
            var person = _personService.Update(id,
                                    firstName,
                                    lastName,
                                    surName,
                                    gender,
                                    birthDate,
                                    snils,
                                    email,
                                    phone,
                                    registrationAddress,
                                    factAddress,
                                    otherPhones);

            var user = _userService.Update(id,
                                    login,
                                    password,
                                    roles);

            return user;
        }

        public IEnumerable<string> GetRoles(ClaimsIdentity identity)
        {
            var identityRoles = identity.Claims
                            .Where(c => c.Type == ClaimTypes.Role)
                            .Select(c => c.Value);

            return identityRoles;
        }
    }
}
