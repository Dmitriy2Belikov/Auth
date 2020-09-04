using Auth.DataLayer.ConfigurationModules.Common;
using Auth.DataLayer.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.ConfigurationModules
{
    public class TasksAppConfig : IModuleConfig
    {
        private static Lazy<TasksAppConfig> _instance = new Lazy<TasksAppConfig>(() => new TasksAppConfig());

        public static TasksAppConfig Instance = _instance.Value;

        public Guid SystemModuleId { get; }
        public List<Catalog> Catalogs { get; }

        public TasksAppConfig()
        {
            SystemModuleId = SystemModules.Tasks.Id;

            Catalogs = new List<Catalog>()
            {
                TasksAppCatalogs.TasksConfigurationCatalog,
                TasksAppCatalogs.TaskDefaultTeamsCatalog,
                TasksAppCatalogs.TaskTaskCatalog,
                TasksAppCatalogs.TaskRoleCatalog,
                TasksAppCatalogs.TaskUserCatalog
            };
        }

        private static class TasksAppCatalogs
        {
            public static Catalog TasksConfigurationCatalog = new Catalog(WorkingEntities.TasksConfiguration.Id, new List<CatalogOperation>()
            {
                new CatalogOperation(){Id = Guid.Parse("1b984a78-93a0-4bc6-a766-b2240edddede"), Title = "Просмотр"      },
                new CatalogOperation(){Id = Guid.Parse("216daa64-0f6a-422f-a879-b9242e3c7c44"), Title = "Редактирование"},
            });

            public static Catalog TaskDefaultTeamsCatalog = new Catalog(WorkingEntities.DefaultTeams.Id, new List<CatalogOperation>()
            {
                new CatalogOperation(){Id = Guid.Parse("d6a3c6de-9110-40af-b550-dc2213b6538d"), Title = "Просмотр"      },
                new CatalogOperation(){Id = Guid.Parse("04f7dbb6-ba8b-4695-94e4-5e5c12fc63bf"), Title = "Редактирование"},
            });

            public static Catalog TaskTaskCatalog = new Catalog(WorkingEntities.Tasks.Id, new List<CatalogOperation>()
            {
                new CatalogOperation(){Id = Guid.Parse("bf8196f2-83f5-4d48-9812-c53acc24566b"), Title = "Просмотр задач"                    },
                new CatalogOperation(){Id = Guid.Parse("8fede856-0eec-4e37-afae-1e286177ba21"), Title = "Постановка задач"                  },
                new CatalogOperation(){Id = Guid.Parse("6c681703-ba46-40d8-8eee-c7b830c436f4"), Title = "Редактирование основной информации"},
                new CatalogOperation(){Id = Guid.Parse("4d7ba5bb-0797-4adc-9931-7440d9ad3a33"), Title = "Редактирование набора ресурсов"    },
                new CatalogOperation(){Id = Guid.Parse("e8e71ca6-4e09-4148-a39c-3629b1619c15"), Title = "Редактирование набора работ"       },
                new CatalogOperation(){Id = Guid.Parse("62a0a2bb-0b0a-4e64-9eb3-00274170388a"), Title = "Ввод результатов выполнения"       },
                new CatalogOperation(){Id = Guid.Parse("a3d7d1f3-6103-4a51-aac1-779bfbe97cd4"), Title = "Удаление"                          },
                new CatalogOperation(){Id = Guid.Parse("967015c6-96e5-4228-a520-2fb942b44108"), Title = "Подтверждение"                     },
            });

            public static Catalog TaskRoleCatalog = new Catalog(WorkingEntities.Roles.Id, new List<CatalogOperation>()
            {
                new CatalogOperation(){Id = Guid.Parse("2c5ad493-c103-42ba-8f02-067bd85cfc63"), Title = "Просмотр списка ролей"     },
                new CatalogOperation(){Id = Guid.Parse("54eda8d7-f7a1-4e03-9aea-2f63f189edce"), Title = "Просмотр информации о роли"},
                new CatalogOperation(){Id = Guid.Parse("8a1eb2fa-91c6-4167-94e7-692148651ab7"), Title = "Создание ролей"            },
                new CatalogOperation(){Id = Guid.Parse("9339d5d5-aab6-490b-8cf5-56a59296b7db"), Title = "Редактирование ролей"      },
            });

            public static Catalog TaskUserCatalog = new Catalog(WorkingEntities.Users.Id, new List<CatalogOperation>()
            {
                new CatalogOperation(){Id = Guid.Parse("a2159f2c-cb05-402e-97e8-38e184ca9c36"), Title = "Просмотр списка пользователей"           },
                new CatalogOperation(){Id = Guid.Parse("c28ebd53-2c40-4649-aaac-0cbde29f1c0d"), Title = "Создание пользователей"                  },
                new CatalogOperation(){Id = Guid.Parse("31b2d470-5244-4747-b48a-b4547199a93c"), Title = "Редактирование данных пользователя"      },
                new CatalogOperation(){Id = Guid.Parse("9c8a2d55-c21c-4854-a53c-101980710e89"), Title = "Редактирование прав доступа пользователя"},
                new CatalogOperation(){Id = Guid.Parse("3a49998e-4200-4833-ae9b-b5967cefc73c"), Title = "Назначение заместителем"                 },
                new CatalogOperation(){Id = Guid.Parse("405964f7-f459-48d7-a046-3640ba1ebda9"), Title = "Блокировка пользователей"                },
            });
        }
    }
}
