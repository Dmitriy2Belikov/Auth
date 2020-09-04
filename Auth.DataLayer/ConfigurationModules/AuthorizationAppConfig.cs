using Auth.DataLayer.ConfigurationModules.Common;
using Auth.DataLayer.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.ConfigurationModules
{
    public class AuthorizationAppConfig : IModuleConfig
    {
        private static Lazy<AuthorizationAppConfig> _instance = new Lazy<AuthorizationAppConfig>(() => new AuthorizationAppConfig());

        public static AuthorizationAppConfig Instance = _instance.Value;

        public Guid SystemModuleId { get; }
        public List<Catalog> Catalogs { get; }

        private AuthorizationAppConfig()
        {
            SystemModuleId = SystemModules.Auth.Id;

            Catalogs = new List<Catalog>()
            {
                
            };
        }

        private static class AuthorizationAppCatalogs
        {

        }
    }
}
