using Auth.DataLayer.ConfigurationModules.Common;
using Auth.DataLayer.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.ConfigurationModules
{
    public class ResourceAppConfig : IModuleConfig
    {
        private static Lazy<ResourceAppConfig> _instance = new Lazy<ResourceAppConfig>(() => new ResourceAppConfig());

        public static ResourceAppConfig Instance = _instance.Value;

        public Guid SystemModuleId { get; }
        public List<Catalog> Catalogs { get; }

        public ResourceAppConfig()
        {
            SystemModuleId = SystemModules.Resources.Id;

            Catalogs = new List<Catalog>()
            {
                ResourceAppCatalogs.ResourceTeamCatalog,
                ResourceAppCatalogs.ResourceResourceCatalog,
                ResourceAppCatalogs.ResourceUserCatalog,
                ResourceAppCatalogs.ResourceRoleCatalog
            };
        }

        private static class ResourceAppCatalogs
        {
            public static Catalog ResourceTeamCatalog = new Catalog(WorkingEntities.Teams.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() { Id = Guid.Parse("525fe42c-1a53-40a8-8eb5-a17bd9aef35a"), Title = "Просмотр списка бригад"},
                new CatalogOperation() { Id = Guid.Parse("9c46e669-5086-4d89-907f-360595985581"), Title = "Создание бригад"       },
                new CatalogOperation() { Id = Guid.Parse("b285ff79-d7bc-4cd2-8c73-1bb0c48ebb0d"), Title = "Редактирование бригад" },
            });

            public static Catalog ResourceResourceCatalog = new Catalog(WorkingEntities.Resources.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() { Id = Guid.Parse("45209133-a4f6-401e-820a-1bc3956dac29"), Title = "Просмотр списка ресурсов" },
                new CatalogOperation() { Id = Guid.Parse("4ed039e9-75f3-49b5-82a2-04797bfede60"), Title = "Создание ресурсов"        },
                new CatalogOperation() { Id = Guid.Parse("00ec0627-1872-48ce-95ce-92e996c2acec"), Title = "Редактирование ресурсов"  },
                new CatalogOperation() { Id = Guid.Parse("30f0adf5-9082-4647-b74d-332d1f50079b"), Title = "Пометить неактивным"      },
                new CatalogOperation() { Id = Guid.Parse("f48e6f66-af7a-4e5e-8f0b-a81ff824c049"), Title = "Восстановить активность"  },
            });

            public static Catalog ResourceUserCatalog = new Catalog(WorkingEntities.Users.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() { Id = Guid.Parse("8d410a01-c070-4ae7-a84c-677ba26a3830"), Title = "Просмотр списка пользователей"           },
                new CatalogOperation() { Id = Guid.Parse("7262a522-4fa3-47ed-a3a9-c17748ff951b"), Title = "Создание пользователей"                  },
                new CatalogOperation() { Id = Guid.Parse("77715124-83d6-46ef-9913-725a37bf8d95"), Title = "Редактирование данных пользователя"      },
                new CatalogOperation() { Id = Guid.Parse("ae205791-60b5-494e-a3c5-fd6144e802e3"), Title = "Редактирование прав доступа пользователя"},
                new CatalogOperation() { Id = Guid.Parse("b7efeecd-7749-4306-aeb4-4a1952aaab1c"), Title = "Назначение заместителем"                 },
                new CatalogOperation() { Id = Guid.Parse("2b246356-f9bb-4f20-8d25-69ce75b44748"), Title = "Блокировка пользователей"                },
            });

            public static Catalog ResourceRoleCatalog = new Catalog(WorkingEntities.Roles.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() { Id = Guid.Parse("5cc23e45-e663-4680-bd67-63b2dec56c9d"), Title = "Просмотр списка ролей"     },
                new CatalogOperation() { Id = Guid.Parse("b23d9c54-38f1-4d2b-93e5-fe0d25355ee6"), Title = "Просмотр информации о роли"},
                new CatalogOperation() { Id = Guid.Parse("f4029998-47de-44b7-93fe-3ba78dd86621"), Title = "Создание ролей"            },
                new CatalogOperation() { Id = Guid.Parse("34b55bb0-5c61-4371-968b-db07e96c8887"), Title = "Редактирование ролей"      },
            });
        }
    }
}
