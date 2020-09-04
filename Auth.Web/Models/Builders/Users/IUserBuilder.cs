using Auth.DataLayer.Models;
using Auth.Web.Forms.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Web.Models.Builders.Users
{
    public interface IUserBuilder
    {
        User BuildNew(Guid personId, RegisterUserForm registerUserForm);
    }
}
