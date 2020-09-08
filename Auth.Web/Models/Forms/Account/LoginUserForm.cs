using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Web.Forms.Account
{
    public class LoginUserForm
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string UserAgent { get; set; }
    }
}
