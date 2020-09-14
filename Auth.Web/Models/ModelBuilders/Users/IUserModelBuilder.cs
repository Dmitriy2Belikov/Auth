using Auth.DataLayer.Models.Persons;
using Auth.DataLayer.Models.Users;
using Auth.Web.Models.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Web.Models.ModelBuilders.Users
{
    public interface IUserModelBuilder
    {
        UserViewModel BuildNew(User user);
    }
}
