using Auth.DataLayer.Models;
using Auth.Web.Forms.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Web.Models.Builders.Persons
{
    public interface IPersonBuilder
    {
        Person BuildNew(RegisterUserForm registerUserForm);
    }
}
