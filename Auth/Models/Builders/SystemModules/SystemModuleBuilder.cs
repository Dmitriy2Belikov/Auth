using Auth.DataLayer.Models;
using Auth.Web.Models.ViewModels.SystemModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Web.Models.Builders.SystemModules
{
    public class SystemModuleBuilder : ISystemModuleBuilder
    {
        public SystemModuleViewModel BuildViewModel(SystemModule systemModule)
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
