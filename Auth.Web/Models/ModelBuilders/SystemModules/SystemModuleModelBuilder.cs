using Auth.DataLayer.Models.SystemModules;
using Auth.Web.Models.ViewModels.SystemModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Web.Models.ModelBuilders.SystemModules
{
    public class SystemModuleModelBuilder : ISystemModuleModelBuilder
    {
        public SystemModuleViewModel BuildNew(SystemModule systemModule)
        {
            var systemModuleViewModel = new SystemModuleViewModel()
            {
                Id = systemModule.Id,
                Title = systemModule.Title
            };

            return systemModuleViewModel;
        }
    }
}
