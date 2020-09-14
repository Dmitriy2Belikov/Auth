using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.Models.Users
{
    public interface IUserFactory
    {
        User Create(Guid personId, string login, string password);
        User Edit(Guid id, string login, string password);
    }
}
