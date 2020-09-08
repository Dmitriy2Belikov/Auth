using Auth.DataLayer.Models;
using Auth.Services.AccountServices.BrowserDataModel;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Auth.Services.AccountServices
{
    public interface IAccountService
    {
        (string AccessToken, string RefreshToken) GetNewTokenPair(string login, string refresh);
        (string AccessToken, string RefreshToken) Login(string login, string password, BrowserData browserData);
        ClaimsIdentity GetIdentity(User user);
        User Register(User user, Person person, IEnumerable<Role> roles);
        bool Verify(User user, string password);
    }
}
