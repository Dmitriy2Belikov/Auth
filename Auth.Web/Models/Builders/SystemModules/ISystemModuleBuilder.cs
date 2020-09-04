using Auth.DataLayer.Models;
using Auth.Web.Models.ViewModels.SystemModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Web.Models.Builders.SystemModules
{
    public interface ISystemModuleBuilder
    {
        SystemModuleViewModel BuildViewModel(SystemModule systemModule);
    }
}
