using Auth.DataLayer.Enums;
using Auth.DataLayer.Models.Persons;
using Auth.DataLayer.Models.Roles;
using Auth.DataLayer.Models.Users;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Auth.Services.AccountServices
{
    public interface IAccountService
    {
        (string AccessToken, string RefreshToken) GetNewTokenPair(User user, ClaimsIdentity identity, string refresh);
        (string AccessToken, string RefreshToken) Login(User user, ClaimsIdentity identity);
        ClaimsIdentity GetIdentity(User user);
        User Register(string login,
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
            IEnumerable<Role> roles);
        bool Verify(User user, string password);
        void RemoveProfile(Guid userId);
        User EditProfile(Guid id,
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
            string otherPhones);
        IEnumerable<string> GetRoles(ClaimsIdentity identity);
    }
}
