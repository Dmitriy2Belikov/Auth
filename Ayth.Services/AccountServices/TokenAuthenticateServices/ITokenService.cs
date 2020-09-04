using Auth.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Auth.Services.AccountServices.TokenAuthenticateServices
{
    public interface ITokenService
    {
        RefreshSession BuildNewRefreshSession(Guid userId, string ip, string userAgent, string refreshToken);
        string BuildNewAccessToken(ClaimsIdentity identity);
        string BuildNewRefreshToken();
        void RemoveOldRefreshSession(Guid id);
        RefreshSession GetRefreshSession(string token);
        void AddRefreshSession(RefreshSession session);
        bool VerifyRefreshToken(User user, string token);
    }
}
