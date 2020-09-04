using Auth.DataLayer.ConfigurationModules.Common;
using Auth.DataLayer.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.ConfigurationModules
{
    public class ApiAppConfig : IModuleConfig
    {
        private static Lazy<ApiAppConfig> _instance = new Lazy<ApiAppConfig>(() => new ApiAppConfig());

        public static ApiAppConfig Instance = _instance.Value;

        public Guid SystemModuleId { get; }
        public List<Catalog> Catalogs { get; }

        private ApiAppConfig()
        {
            SystemModuleId = SystemModules.Api.Id;

            Catalogs = new List<Catalog>()
            {
                ApiAppCatalogs.ApiAccessCatalog
            };
        }

        private static class ApiAppCatalogs
        {
            public static Catalog ApiAccessCatalog = new Catalog(WorkingEntities.ApiAccess.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() { Id = Guid.Parse("d6f4d3e1-5100-4a67-a204-c5da9977a54e"), Title = "Общий доступ к API" },
                new CatalogOperation() { Id = Guid.Parse("32962a0b-5d05-4aba-9f93-07b057255597"), Title = "Доступ к API для ПК АНПБ" }
            });
        }
    }
}
