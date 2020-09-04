using Auth.DataLayer.Models;
using Auth.DataLayer.Repositories.ModelRepos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.Repositories.RefreshSessionRepos
{
    public interface IRefreshSessionRepository : IModelRepository<RefreshSession>
    {
        RefreshSession Get(Guid userId, string IP, string userAgent);
        RefreshSession GetByToken(string token);
    }
}
