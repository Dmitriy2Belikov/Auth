using Auth.DataLayer.ConfigurationModules.Common;
using Auth.DataLayer.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.ConfigurationModules
{
    public class ReportsAppConfig : IModuleConfig
    {
        private static Lazy<ReportsAppConfig> _instance = new Lazy<ReportsAppConfig>(() => new ReportsAppConfig());

        public static ReportsAppConfig Instance = _instance.Value;

        public Guid SystemModuleId { get; }
        public List<Catalog> Catalogs { get; }

        public ReportsAppConfig()
        {
            SystemModuleId = SystemModules.Reports.Id;

            Catalogs = new List<Catalog>()
            {
                ReportsAppCatalogs.ReportsRoleCatalog,
                ReportsAppCatalogs.ReportsUserCatalog,
            };
        }

        private static class ReportsAppCatalogs
        {
            public static Catalog ReportsRoleCatalog = new Catalog(WorkingEntities.Roles.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() { Id = Guid.Parse("7de4c4a6-4aca-459b-b414-4dff2f2c7601"), Title = "Просмотр списка ролей"      },
                new CatalogOperation() { Id = Guid.Parse("603147ac-2065-42ec-8b39-200a5a35aeb9"), Title = "Просмотр информации о роли" },
                new CatalogOperation() { Id = Guid.Parse("750c3624-fda4-49f4-87c5-2cba83603f15"), Title = "Создание ролей"             },
                new CatalogOperation() { Id = Guid.Parse("4460978c-856c-4362-bcfa-fe1edab98ac5"), Title = "Редактирование ролей"       },
            });

            public static Catalog ReportsUserCatalog = new Catalog(WorkingEntities.Users.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() { Id = Guid.Parse("b84560f4-4453-41df-9cec-af93cb765a09"), Title = "Просмотр списка пользователей"           },
                new CatalogOperation() { Id = Guid.Parse("0b02ac7e-2429-466a-813f-ffdc7fc36b51"), Title = "Создание пользователей"                  },
                new CatalogOperation() { Id = Guid.Parse("540b15aa-5361-4667-9946-a2a1bb755af9"), Title = "Редактирование данных пользователя"      },
                new CatalogOperation() { Id = Guid.Parse("96d57ffb-ad43-4ecc-b1ed-54d960911a8c"), Title = "Редактирование прав доступа пользователя"},
                new CatalogOperation() { Id = Guid.Parse("0f66528c-4643-4cbf-aa6c-d74f60b7c896"), Title = "Назначение заместителем"                 },
                new CatalogOperation() { Id = Guid.Parse("c4856675-4dc0-4c1d-82de-497678c23331"), Title = "Блокировка пользователей"                },
            });
        }
    }
}
