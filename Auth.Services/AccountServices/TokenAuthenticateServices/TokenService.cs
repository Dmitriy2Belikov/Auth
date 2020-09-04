using Auth.DataLayer;
using Auth.DataLayer.Models;
using Auth.DataLayer.Repositories.RefreshSessionRepos;
using Auth.Services.CookieServices.CookieServices;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Auth.Services.AccountServices.TokenAuthenticateServices
{
    public class TokenService : ITokenService
    {
        private IRefreshSessionRepository _refreshSessionRepository;
        private ICookieService _authorizationCookieManager;

        public TokenService(
            IRefreshSessionRepository refreshSessionRepository, 
            ICookieService authorizationCookieManager)
        {
            _refreshSessionRepository = refreshSessionRepository;
            _authorizationCookieManager = authorizationCookieManager;
        }

        public RefreshSession BuildNewRefreshSession(Guid userId, string ip, string userAgent, string refreshToken)
        {
            var refreshSession = new RefreshSession()
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                IP = ip,
                UserAgent = userAgent,
                RefreshToken = refreshToken,
                ExpiresIn = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 2, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second),
                CreatedAt = DateTime.Now
            };

            return refreshSession;
        }

        public string BuildNewAccessToken(ClaimsIdentity identity)
        {
            var now = DateTime.Now;

            var jwt = new JwtSecurityToken(
                            issuer: AuthOptions.ISSUER,
                            audience: AuthOptions.AUDIENCE,
                            notBefore: now,
                            claims: identity.Claims,
                            expires: now.Add(TimeSpan.FromHours(AuthOptions.ACCEESS_TOKEN_LIFETIME_HOURS)),
                            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }

        public string BuildNewRefreshToken()
        {
            var token = Guid.NewGuid().ToString();

            return token;
        }

        public void RemoveOldRefreshSession(Guid id)
        {
            _refreshSessionRepository.Remove(id);
        }

        public RefreshSession GetRefreshSession(string token)
        {
            var refreshSession = _refreshSessionRepository.GetByToken(token);

            return refreshSession;
        }

        public void AddRefreshSession(RefreshSession session)
        {
            _refreshSessionRepository.Add(session);
        }

        public bool VerifyRefreshToken(User user, string token)
        {
            var refreshSession = _refreshSessionRepository.GetByToken(token);

            if (refreshSession != null)
            {
                if (user.Id == refreshSession.UserId && DateTime.Now < refreshSession.ExpiresIn)
                {
                    return refreshSession.RefreshToken.Equals(token);
                }
            }

            return false;
        }
    }
}
