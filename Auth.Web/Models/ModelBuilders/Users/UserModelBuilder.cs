using Auth.DataLayer.Models.Persons;
using Auth.DataLayer.Models.Users;
using Auth.Services.PrimitivesServices.PersonServices;
using Auth.Web.Forms.Account;
using Auth.Web.Models.ModelBuilders.Persons;
using Auth.Web.Models.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Web.Models.ModelBuilders.Users
{
    public class UserModelBuilder : IUserModelBuilder
    {
        private IPersonModelBuilder _personModelBuilder;
        private IPersonService _personService;

        public UserModelBuilder(IPersonModelBuilder personModelBuilder, IPersonService personService)
        {
            _personModelBuilder = personModelBuilder;
            _personService = personService;
        }

        public UserViewModel BuildNew(User user)
        {
            var person = _personService.Get(user.Id);

            var userViewModel = new UserViewModel()
            {
                Id = user.Id,
                Login = user.Login,
                Person = _personModelBuilder.BuildNew(person),
                LastActionTime = user.LastActionTime
            };

            return userViewModel;
        }
    }
}
