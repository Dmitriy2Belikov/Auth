using Auth.DataLayer.ConfigurationModules.Common;
using Auth.DataLayer.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.ConfigurationModules
{
    public class ReglamentAppConfig : IModuleConfig
    {
        private static Lazy<ReglamentAppConfig> _instance = new Lazy<ReglamentAppConfig>(() => new ReglamentAppConfig());

        public static ReglamentAppConfig Instance = _instance.Value;

        public Guid SystemModuleId { get; }
        public List<Catalog> Catalogs { get; }

        public ReglamentAppConfig()
        {
            SystemModuleId = SystemModules.Reglament.Id;

            Catalogs = new List<Catalog>()
            {
                ReglamentAppCatalogs.ReglamentExecutorsCatalog,
                ReglamentAppCatalogs.ReglamentObjectsCatalog,
                ReglamentAppCatalogs.ReglamentYearCatalog,
                ReglamentAppCatalogs.ReglamentUserCatalog,
                ReglamentAppCatalogs.ReglamentRoleCatalog
            };
        }

        private static class ReglamentAppCatalogs
        {
            public static Catalog ReglamentExecutorsCatalog = new Catalog(WorkingEntities.Executors.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() {Id = Guid.Parse("f25eee0e-7518-489c-ad1c-4b5433455b6d"), Title = "Просмотр списка исполнителей"       },
                new CatalogOperation() {Id = Guid.Parse("960789ac-c124-4439-866f-f6c3af8886f5"), Title = "Редактирование списка исполнителей" },
            });

            public static Catalog ReglamentObjectsCatalog = new Catalog(WorkingEntities.Objects.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() {Id = Guid.Parse("e9535218-7fa0-4457-b863-45d795bc26a4"), Title = "Просмотр"               },
                new CatalogOperation() {Id = Guid.Parse("1ee0e6f2-84f1-468f-af31-8a066dc59459"), Title = "Создание объектов"      },
                new CatalogOperation() {Id = Guid.Parse("41da87bf-5004-4769-a92d-401c7759c9b7"), Title = "Редактирование объектов"},
                new CatalogOperation() {Id = Guid.Parse("ad1f4405-e8d1-4704-81fa-a88f1e225a08"), Title = "Удаление объектов"      },
            });

            public static Catalog ReglamentYearCatalog = new Catalog(WorkingEntities.Year.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() {Id = Guid.Parse("3a447acc-4801-44f3-90dd-24ec22e5b9cc"), Title = "Просмотр регламентов"        },
                new CatalogOperation() {Id = Guid.Parse("07c2eab0-7409-40d1-9027-dbaaf49a3428"), Title = "Открытие нового года"        },
                new CatalogOperation() {Id = Guid.Parse("98094f5a-a15f-4534-b88b-f8949a54f649"), Title = "Изменение сезонов"           },
                new CatalogOperation() {Id = Guid.Parse("108a13e2-6137-4482-ae9a-7628b919673b"), Title = "Управление работами на сезон"},
            });

            public static Catalog ReglamentUserCatalog = new Catalog(WorkingEntities.Users.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() {Id = Guid.Parse("cd614464-74be-425e-b74e-23ea5c989d8c"), Title = "Просмотр списка пользователей"           },
                new CatalogOperation() {Id = Guid.Parse("781a6a02-6cbc-472d-9276-e92b27a6b10b"), Title = "Создание пользователей"                  },
                new CatalogOperation() {Id = Guid.Parse("6d79002b-b583-4160-bd92-5798e59ff1e0"), Title = "Редактирование данных пользователя"      },
                new CatalogOperation() {Id = Guid.Parse("cbf4a731-246b-470b-bcb9-b34ebb522044"), Title = "Редактирование прав доступа пользователя"},
                new CatalogOperation() {Id = Guid.Parse("5bb0fa36-66cc-451b-af1f-51a81f35d2c9"), Title = "Назначение заместителем"                 },
                new CatalogOperation() {Id = Guid.Parse("a8198f71-1b01-4f21-a068-c242833a9587"), Title = "Блокировка пользователей"                },
            });

            public static Catalog ReglamentRoleCatalog = new Catalog(WorkingEntities.Roles.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() {Id = Guid.Parse("f0dcfce1-63a1-4fad-b46c-8e04d765f218"), Title = "Просмотр списка ролей"      },
                new CatalogOperation() {Id = Guid.Parse("72c017fb-fcbd-4a27-977c-1cca2abf6609"), Title = "Просмотр информации о роли" },
                new CatalogOperation() {Id = Guid.Parse("19b24c95-2668-466a-93f7-c20aa5e98ea8"), Title = "Создание ролей"             },
                new CatalogOperation() {Id = Guid.Parse("564d424f-88ad-4e21-8b5d-ba93092f9b89"), Title = "Редактирование ролей"       },
            });
        }
    }
}
