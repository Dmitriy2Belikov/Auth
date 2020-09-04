using Auth.DataLayer.ConfigurationModules.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.ConfigurationModules
{
    public interface IModuleConfig
    {
        Guid SystemModuleId { get; }

        List<Catalog> Catalogs { get; }
    }
}
