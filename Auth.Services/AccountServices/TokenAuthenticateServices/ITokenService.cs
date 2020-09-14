using Auth.DataLayer.Models;
using Auth.DataLayer.Models.RefreshSessions;
using Auth.DataLayer.Models.Users;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Auth.Services.AccountServices.TokenAuthenticateServices
{
    public interface ITokenService
    {
        RefreshSession BuildNewRefreshSession(Guid userId, string refreshToken);
        string BuildNewAccessToken(ClaimsIdentity identity);
        string BuildNewRefreshToken();
        void RemoveRefreshSession(Guid id);
        RefreshSession GetRefreshSession(string token);
        void AddRefreshSession(RefreshSession session);
        bool VerifyRefreshToken(User user, string token);
    }
}
