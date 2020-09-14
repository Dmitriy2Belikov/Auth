using Auth.DataLayer.Models;
using Auth.DataLayer.Models.RefreshSessions;
using Auth.DataLayer.Repositories.ModelRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Auth.DataLayer.Repositories.RefreshSessionRepos
{
    public class RefreshSessionRepository : ModelRepository<RefreshSession>, IRefreshSessionRepository
    {
        private UserDbContext _context;

        public RefreshSessionRepository(UserDbContext context) : base(context)
        {
            _context = context;
        }

        public RefreshSession GetByUserId(Guid userId)
        {
            var refreshSession = _context.RefreshSessions.FirstOrDefault(r => r.UserId == userId);

            return refreshSession;
        }

        public RefreshSession GetByToken(string token)
        {
            var session = _context.RefreshSessions.FirstOrDefault(r => r.RefreshToken == token);

            return session;
        }
    }
}
