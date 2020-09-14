using Auth.DataLayer.Models.SystemModules;
using Auth.Web.Models.ViewModels.SystemModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Web.Models.ModelBuilders.SystemModules
{
    public interface ISystemModuleModelBuilder
    {
        SystemModuleViewModel BuildNew(SystemModule systemModule);
    }
}
