using Auth.DataLayer.ConfigurationModules.Common;
using Auth.DataLayer.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.ConfigurationModules
{
    public class AnalyticsAppConfig : IModuleConfig
    {
        private static Lazy<AnalyticsAppConfig> _instance = new Lazy<AnalyticsAppConfig>(() => new AnalyticsAppConfig());

        public static AnalyticsAppConfig Instance = _instance.Value;

        public Guid SystemModuleId { get; }
        public List<Catalog> Catalogs { get; }

        private AnalyticsAppConfig()
        {
            SystemModuleId = SystemModules.Analytics.Id;

            Catalogs = new List<Catalog>()
            {
                AnalyticsAppCatalogs.ReportCatalog
            };
        }

        private static class AnalyticsAppCatalogs
        {
            public static Catalog ReportCatalog = new Catalog(WorkingEntities.AnalyticsReports.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() { Id = Guid.Parse("9e76665e-343f-42e8-86d0-14211f37ac31"), Title = "Отчёты раздела 'Квартальные'" }
            });
        }
    }
}
