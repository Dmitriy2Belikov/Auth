using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.Services.AccountServices.ValidateServices
{
    public interface IValidateService
    {
        bool IsExistLogin(string login);
    }
}
