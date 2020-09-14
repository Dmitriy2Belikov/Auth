using Auth.DataLayer.Models;
using Auth.DataLayer.Models.RefreshSessions;
using Auth.DataLayer.Repositories.ModelRepos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.Repositories.RefreshSessionRepos
{
    public interface IRefreshSessionRepository : IModelRepository<RefreshSession>
    {
        RefreshSession GetByUserId(Guid userId);
        RefreshSession GetByToken(string token);
    }
}
