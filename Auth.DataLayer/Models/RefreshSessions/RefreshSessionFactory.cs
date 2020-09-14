using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.Models.RefreshSessions
{
    public class RefreshSessionFactory : IRefreshSessionFactory
    {
        public RefreshSession Create(Guid userId, string refreshToken)
        {
            var refreshSession = new RefreshSession()
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                RefreshToken = refreshToken,
                ExpiresIn = DateTime.Now + TimeSpan.FromDays(AuthOptions.REFRESH_TOKEN_LIFETIME_DAYS),
                CreatedAt = DateTime.Now
            };

            return refreshSession;
        }
    }
}
