using Auth.Web.Models.ViewModels.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Web.Models.ViewModels.Users
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public PersonViewModel Person { get; set; }
        public DateTime? LastActionTime { get; set; }
    }
}
