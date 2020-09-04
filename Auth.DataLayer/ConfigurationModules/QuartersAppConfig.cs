using Auth.DataLayer.ConfigurationModules.Common;
using Auth.DataLayer.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.ConfigurationModules
{
    public class QuartersAppConfig : IModuleConfig
    {
        private static Lazy<QuartersAppConfig> _instance = new Lazy<QuartersAppConfig>(() => new QuartersAppConfig());

        public static QuartersAppConfig Instance = _instance.Value;

        public Guid SystemModuleId { get; }
        public List<Catalog> Catalogs { get; }

        public QuartersAppConfig()
        {
            SystemModuleId = SystemModules.Quarters.Id;

            Catalogs = new List<Catalog>()
            {
                QuartersAppCatalogs.QuartersConfigurationCatalog,
                QuartersAppCatalogs.QuarterTerritoriesCatalog,
                QuartersAppCatalogs.QuartersInspectorsCatalog,
                QuartersAppCatalogs.QuartersUserCatalog,
                QuartersAppCatalogs.QuartersRoleCatalog
            };
        }

        private static class QuartersAppCatalogs
        {
            public static Catalog QuartersConfigurationCatalog = new Catalog(WorkingEntities.QuartersConfiguration.Id, new List<CatalogOperation>()
            {
                new CatalogOperation(){Id = Guid.Parse("c1324fcd-504a-4178-8836-00af8e56758a"), Title = "Просмотр"      },
                new CatalogOperation(){Id = Guid.Parse("eb1e4187-284e-42d3-9e52-708b21bd993d"), Title = "Редактирование"},
            });

            public static Catalog QuarterTerritoriesCatalog = new Catalog(WorkingEntities.QuarterTerritories.Id, new List<CatalogOperation>()
            {
                new CatalogOperation(){Id = Guid.Parse("e32dc21e-f944-4a65-ac3c-92b29e9dd6f5"), Title = "Просмотр"      },
                new CatalogOperation(){Id = Guid.Parse("5a5ff657-852b-471b-bfbe-be155bdc2bfe"), Title = "Создание"      },
                new CatalogOperation(){Id = Guid.Parse("ceb8d710-88cd-4fbe-b625-bd5800d515cc"), Title = "Редактирование"},
            });

            public static Catalog QuartersInspectorsCatalog = new Catalog(WorkingEntities.Inspectors.Id, new List<CatalogOperation>()
            {
                new CatalogOperation(){Id = Guid.Parse("dbcad504-5294-48b0-91ee-48d1346a9762"), Title = "Список квартальных"            },
                new CatalogOperation(){Id = Guid.Parse("d7659a51-5390-47ae-a131-26a94e355843"), Title = "Просмотр карточки квартального"},
                new CatalogOperation(){Id = Guid.Parse("adce6d5d-390f-4e28-af6d-744521d0c6bc"), Title = "Создание квартальных"          },
                new CatalogOperation(){Id = Guid.Parse("21f328c9-f161-4af8-b908-4cb4fdc8859d"), Title = "Редактирование квартальных"    },
                new CatalogOperation(){Id = Guid.Parse("099e542b-964e-4d46-9131-891250455f79"), Title = "Увольнение квартальных"        },
                new CatalogOperation(){Id = Guid.Parse("e311029b-907b-41f4-baca-4a01f1fc3de7"), Title = "Восстановление квартальных"    },
            });

            public static Catalog QuartersUserCatalog = new Catalog(WorkingEntities.Users.Id, new List<CatalogOperation>()
            {
                new CatalogOperation(){Id = Guid.Parse("7962bd97-e1f4-4b52-8b18-9ad405bf0494"), Title = "Просмотр списка пользователей"           },
                new CatalogOperation(){Id = Guid.Parse("6113f439-3e93-42c6-b046-44ad038c5ad4"), Title = "Создание пользователей"                  },
                new CatalogOperation(){Id = Guid.Parse("27de3aa7-5fa6-4052-ac66-4090e07b0c03"), Title = "Редактирование данных пользователя"      },
                new CatalogOperation(){Id = Guid.Parse("52ef4598-4e94-4bc6-b5ee-c9afcd569268"), Title = "Редактирование прав доступа пользователя"},
                new CatalogOperation(){Id = Guid.Parse("1fe09dfc-c379-45bc-998d-38d14ab1afc7"), Title = "Назначение заместителем"                 },
                new CatalogOperation(){Id = Guid.Parse("8a5b18ec-d932-4a91-a663-f08b45a60e8c"), Title = "Блокировка пользователей"                },
            });

            public static Catalog QuartersRoleCatalog = new Catalog(WorkingEntities.Roles.Id, new List<CatalogOperation>()
            {
                new CatalogOperation(){Id = Guid.Parse("50ff6a14-242a-4179-a242-30465e27dcf6"), Title = "Просмотр списка ролей"     },
                new CatalogOperation(){Id = Guid.Parse("8e5c586b-353d-4ce1-8a0b-03f69c99234d"), Title = "Просмотр информации о роли"},
                new CatalogOperation(){Id = Guid.Parse("02558c2e-387d-44b6-b5d8-6cf390a7a424"), Title = "Создание ролей"            },
                new CatalogOperation(){Id = Guid.Parse("b21fbe67-0405-4f2b-9947-53ea4a6d772c"), Title = "Редактирование ролей"      },
            });
        }
    }
}
