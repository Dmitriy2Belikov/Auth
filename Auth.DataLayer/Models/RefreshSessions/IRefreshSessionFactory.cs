using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.Models.RefreshSessions
{
    public interface IRefreshSessionFactory
    {
        RefreshSession Create(Guid userId, string refreshToken);
    }
}
