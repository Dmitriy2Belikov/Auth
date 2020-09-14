using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.Models.Roles
{
    public interface IRoleFactory
    {
        Role Create(string name);
        Role Edit(Guid id, string name);
    }
}
