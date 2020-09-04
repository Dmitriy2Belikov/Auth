using Auth.DataLayer.ConfigurationModules.Common;
using Auth.DataLayer.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.ConfigurationModules
{
    public class VehicleMonitoringAppConfig : IModuleConfig
    {
        private static Lazy<VehicleMonitoringAppConfig> _instance = new Lazy<VehicleMonitoringAppConfig>(() => new VehicleMonitoringAppConfig());

        public static VehicleMonitoringAppConfig Instance = _instance.Value;

        public Guid SystemModuleId { get; }
        public List<Catalog> Catalogs { get; }

        public VehicleMonitoringAppConfig()
        {
            SystemModuleId = SystemModules.VehicleMonitoring.Id;

            Catalogs = new List<Catalog>()
            {
                VehicleMonitoringAppCatalogs.VehicleMonitoringCatalog
            };
        }

        private static class VehicleMonitoringAppCatalogs
        {
            public static Catalog VehicleMonitoringCatalog = new Catalog(WorkingEntities.VehicleMonitoring.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() { Id = Guid.Parse("1091fdf3-ee3a-4dff-a941-a485748ca2d2"), Title = "Отслеживание техники на карте"}
            });
        }
    }
}
