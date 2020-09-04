using Auth.DataLayer.ConfigurationModules.Common;
using Auth.DataLayer.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.ConfigurationModules
{
    public class TrafficLightsAppConfig : IModuleConfig
    {
        private static Lazy<TrafficLightsAppConfig> _instance = new Lazy<TrafficLightsAppConfig>(() => new TrafficLightsAppConfig());

        public static TrafficLightsAppConfig Instance = _instance.Value;

        public Guid SystemModuleId { get; }
        public List<Catalog> Catalogs { get; }

        public TrafficLightsAppConfig()
        {
            SystemModuleId = SystemModules.TrafficLights.Id;

            Catalogs = new List<Catalog>()
            {
                TrafficLightsAppCatalogs.TrafficLightsViolationCatalog
            };
        }

        private static class TrafficLightsAppCatalogs
        {
            public static Catalog TrafficLightsViolationCatalog = new Catalog(WorkingEntities.TrafficLightsViolations.Id, new List<CatalogOperation>()
            {
                new CatalogOperation(){Id = Guid.Parse("b61225fe-7c07-4151-b546-360cf6a99a76"), Title = "Просмотр нарушений"       },
                new CatalogOperation(){Id = Guid.Parse("ae3f4b29-eb3c-404c-be61-74cb384d5aed"), Title = "Создание нарушений"       },
                new CatalogOperation(){Id = Guid.Parse("ba1a3b66-340b-41cf-a9d4-f9441cd76603"), Title = "Редактирование нарушений" },
                new CatalogOperation(){Id = Guid.Parse("e36fb93d-acd0-428d-b93b-f4021e34211d"), Title = "Комментирование нарушений"},
            });
        }
    }
}
