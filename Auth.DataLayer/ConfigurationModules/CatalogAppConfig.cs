using Auth.DataLayer.ConfigurationModules.Common;
using Auth.DataLayer.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.ConfigurationModules
{
    public class CatalogAppConfig : IModuleConfig
    {
        private static Lazy<CatalogAppConfig> _instance = new Lazy<CatalogAppConfig>(() => new CatalogAppConfig());

        public static CatalogAppConfig Instance = _instance.Value;

        public Guid SystemModuleId { get; }
        public List<Catalog> Catalogs { get; }

        private CatalogAppConfig()
        {
            SystemModuleId = SystemModules.Catalog.Id;

            Catalogs = new List<Catalog>()
            {
                CatalogAppCatalogs.PartnerResponsiblePersonCatalog         ,
                CatalogAppCatalogs.ViolationArticlesCatalog                ,
                CatalogAppCatalogs.ViolationGeneratedDocumentTypesCatalog  ,
                CatalogAppCatalogs.ViolationTypesCatalog                   ,
                CatalogAppCatalogs.PlaceTypesCatalog                       ,
                CatalogAppCatalogs.PlaceParametersCatalog                  ,
                CatalogAppCatalogs.PlaceCategoryCatalog                    ,
                CatalogAppCatalogs.PartnerTypeCatalog                      ,
                CatalogAppCatalogs.PartnerCatalog                          ,
                CatalogAppCatalogs.MaterialCatalog                         ,
                CatalogAppCatalogs.StreetsCatalog                          ,
                CatalogAppCatalogs.WorkCatalog                             ,
                CatalogAppCatalogs.WorkParamsCatalog                       ,
                CatalogAppCatalogs.ObjectCategoriesCatalog                 ,
                CatalogAppCatalogs.ObjectParamsCatalog                     ,
                CatalogAppCatalogs.DistrictCatalog                         ,
                CatalogAppCatalogs.ObjectTypeCatalog                       ,
                CatalogAppCatalogs.TaskTypeCatalog                         ,
                CatalogAppCatalogs.ResTypeCatalog                          ,
                CatalogAppCatalogs.OrgTypeCatalog                          ,
                CatalogAppCatalogs.OrgCatalog                              ,
                CatalogAppCatalogs.UserCatalog                             ,
                CatalogAppCatalogs.RoleCatalog
            };
        }

        private static class CatalogAppCatalogs
        {
            public static Catalog PartnerResponsiblePersonCatalog = new Catalog(WorkingEntities.PartnerResponsiblePersons.Id, new List<CatalogOperation>()
            {
                new CatalogOperation(){ Id = Guid.Parse("8f78d63f-ff11-4dd5-8205-d7b4d653abf0"), Title = "Просмотр должностных лиц"},
                new CatalogOperation(){ Id = Guid.Parse("0870ff5a-d73a-4083-992c-e92c3ec48eb1"), Title = "Создание должностных лиц"},
                new CatalogOperation(){ Id = Guid.Parse("afc515cf-3219-4791-8eec-a64a21bd8d95"), Title = "Редактирование должностных лиц" }
            });

            public static Catalog ViolationArticlesCatalog = new Catalog(WorkingEntities.ViolationArticles.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() { Id = Guid.Parse("f3f79333-ad8d-43a7-903c-b7310a1b2d3d"), Title = "Просмотр списка статей"},
                new CatalogOperation() { Id = Guid.Parse("0ceed451-a8a6-4986-b1de-c501dbf3b204"), Title = "Создание статей"      },
                new CatalogOperation() { Id = Guid.Parse("a127e79b-42aa-41c0-81ed-4c1da1d3a814"), Title = "Редактирование статей"},
                new CatalogOperation() { Id = Guid.Parse("7e9c878b-7d20-433c-8bdb-3979c88825d9"), Title = "Удаление статей"      },
            });

            public static Catalog ViolationGeneratedDocumentTypesCatalog = new Catalog(WorkingEntities.ViolationGeneratedDocumentTypes.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() { Id = Guid.Parse("c504cd4b-8a92-4b55-a695-7eeff9c73d10"), Title = "Просмотр списка типов формируемых документов"},
                new CatalogOperation() { Id = Guid.Parse("becfaacc-790a-417e-ab1d-ef6521964c81"), Title = "Создание типов формируемых документов"       },
                new CatalogOperation() { Id = Guid.Parse("c43da40b-4c6d-4517-a2b2-4c280b759431"), Title = "Редактирование типов формируемых документов" },
            });

            public static Catalog ViolationTypesCatalog = new Catalog(WorkingEntities.ViolationTypes.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() { Id = Guid.Parse("7e847837-48ee-432b-9ec6-68a4bdf79204"), Title = "Просмотр типов нарушений"      },
                new CatalogOperation() { Id = Guid.Parse("40e70330-4ea2-4cfb-b38b-b7fc7721029b"), Title = "Создание типов нарушений"      },
                new CatalogOperation() { Id = Guid.Parse("10962976-7e7b-4f8c-9a5e-96a5d83f4549"), Title = "Редактирование типов нарушений"},
            });

            public static Catalog PlaceTypesCatalog = new Catalog(WorkingEntities.PlaceTypes.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() { Id = Guid.Parse("ed656e98-3791-413f-b175-92fbd8d1f59f"), Title = "Просмотр списка типов"},
                new CatalogOperation() { Id = Guid.Parse("f7aea00d-c214-4303-abf2-bff4b4bad220"), Title = "Создание типов"       },
                new CatalogOperation() { Id = Guid.Parse("c018d621-7e8d-4528-9c0a-ba84f568f7dd"), Title = "Редактирование типов" },
                new CatalogOperation() { Id = Guid.Parse("fb01c152-5831-4e8e-8ce8-dda005cc6a10"), Title = "Удаление типов"       },
            });

            public static Catalog PlaceParametersCatalog = new Catalog(WorkingEntities.PlaceParameters.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() { Id = Guid.Parse("6afc3f96-711a-4ab9-8363-49bab7693fea"), Title = "Просмотр списка параметров"},
                new CatalogOperation() { Id = Guid.Parse("3b375ad2-d808-469f-9588-82460cf90c01"), Title = "Создание параметров"       },
                new CatalogOperation() { Id = Guid.Parse("06023bff-e05d-4c8d-97d0-fa89ed134e60"), Title = "Редактирование параметров" },
                new CatalogOperation() { Id = Guid.Parse("92b60433-a502-42cc-aad2-7b05a863e88f"), Title = "Удаление параметров"       },
            });

            public static Catalog PlaceCategoryCatalog = new Catalog(WorkingEntities.PlaceCategories.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() { Id = Guid.Parse("165adc4f-2544-4cd2-966f-ebe06f3dc8c8"), Title = "Просмотр списка категорий"},
                new CatalogOperation() { Id = Guid.Parse("db08c7d4-4866-449a-9441-a9a577567958"), Title = "Создание категорий"       },
                new CatalogOperation() { Id = Guid.Parse("0730b50d-3745-429a-9ad4-65327edf948b"), Title = "Редактирование категорий" },
                new CatalogOperation() { Id = Guid.Parse("1df36941-46f1-4181-8589-0c0e9f51b300"), Title = "Удаление категорий"       },
            });

            public static Catalog PartnerTypeCatalog = new Catalog(WorkingEntities.PartnerTypes.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() { Id = Guid.Parse("697d3127-f190-4aca-b42b-b0555f520411"), Title = "Просмотр типов"       },
                new CatalogOperation() { Id = Guid.Parse("dc4d3554-b0c6-4334-a4a9-4d9ddd8bda6e"), Title = "Создание типов"       },
                new CatalogOperation() { Id = Guid.Parse("d571fbf4-a94e-463b-a9bd-6ece581332b2"), Title = "Редактирование типов" },
            });

            public static Catalog PartnerCatalog = new Catalog(WorkingEntities.Partners.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() { Id = Guid.Parse("3c29c8da-efdc-4bb5-abe3-5d23356890bb"), Title = "Просмотр контрагентов"       },
                new CatalogOperation() { Id = Guid.Parse("b2630847-f8c6-436d-873f-5524234cf7cd"), Title = "Создание контрагентов"       },
                new CatalogOperation() { Id = Guid.Parse("5f20bc0d-8925-4d21-9abf-82ca162807d9"), Title = "Редактирование контрагентов" },
            });

            public static Catalog MaterialCatalog = new Catalog(WorkingEntities.Materials.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() { Id = Guid.Parse("e5755577-3ff7-4036-a448-8809fbefec7d"), Title = "Просмотр"                  },
                new CatalogOperation() { Id = Guid.Parse("9c4c01ec-b338-4f23-8315-b9611207b96c"), Title = "Создание новых материалов" },
                new CatalogOperation() { Id = Guid.Parse("b1507410-5011-40b4-9266-7972893497fc"), Title = "Редактирование материалов" },
            });

            public static Catalog StreetsCatalog = new Catalog(WorkingEntities.Streets.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() { Id = Guid.Parse("07aaafd5-fa91-4899-baa5-2eb8a8d14d6d"), Title = "Просмотр"            },
                new CatalogOperation() { Id = Guid.Parse("6493ee2a-8d53-4095-a7b7-c2f7a59174d3"), Title = "Создание новых улиц" },
                new CatalogOperation() { Id = Guid.Parse("3ed9efc5-df45-4f15-ba3e-99f0dc6d65f4"), Title = "Редактирование улиц" },
            });

            public static Catalog WorkCatalog = new Catalog(WorkingEntities.Works.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() { Id = Guid.Parse("d1249d1e-360c-4ea4-b676-fc211ce0544f"), Title = "Просмотр"             },
                new CatalogOperation() { Id = Guid.Parse("102394c5-21f5-48d9-9a69-e07faf4093f9"), Title = "Создание новых работ" },
                new CatalogOperation() { Id = Guid.Parse("7ad1dbf8-6ed9-4e6e-9f3d-171843b5e0c7"), Title = "Редактирование работ" },
            });

            public static Catalog WorkParamsCatalog = new Catalog(WorkingEntities.WorkParams.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() { Id = Guid.Parse("0f3ce0ba-6092-4335-a69e-aec7c7b9fc4f"), Title = "Просмотр списка параметров" },
                new CatalogOperation() { Id = Guid.Parse("84f69798-a9ab-43eb-bf96-5b2f641d33a9"), Title = "Создание параметорв"        },
                new CatalogOperation() { Id = Guid.Parse("798e9b11-a0c2-40df-93e9-10a7c344c4d0"), Title = "Редактирование параметров"  },
            });

            public static Catalog ObjectCategoriesCatalog = new Catalog(WorkingEntities.ObjectCategories.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() { Id = Guid.Parse("f28297f8-02a5-43e9-9c39-3dadda63d5c4"), Title = "Просмотр списка категорий" },
                new CatalogOperation() { Id = Guid.Parse("688c81e7-e364-4ac7-8049-368c80b2131d"), Title = "Создание категорий"        },
                new CatalogOperation() { Id = Guid.Parse("48683fb3-7396-44cb-9e62-391c883b99f5"), Title = "Редактирование категорий"  },
            });

            public static Catalog ObjectParamsCatalog = new Catalog(WorkingEntities.ObjectParams.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() { Id = Guid.Parse("15070a8d-fd36-4055-9168-60063ba5860b"), Title = "Просмотр списка параметров" },
                new CatalogOperation() { Id = Guid.Parse("4b671c79-64d6-4ae8-9b84-ce58df3d3c61"), Title = "Создание параметорв"        },
                new CatalogOperation() { Id = Guid.Parse("6be1e79e-3850-4e7c-bcec-b5b6e0e338fe"), Title = "Редактирование параметров"  },
            });

            public static Catalog DistrictCatalog = new Catalog(WorkingEntities.Districts.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() { Id = Guid.Parse("455b9cb9-cd31-4beb-a140-991e666ed81d"), Title = "Просмотр списка районов"       },
                new CatalogOperation() { Id = Guid.Parse("d3fa3ca0-1a0a-4d91-817b-2a7a7ff25bfa"), Title = "Создание районов"              },
                new CatalogOperation() { Id = Guid.Parse("45a2653b-4737-4b6b-a385-73698391ae2c"), Title = "Редактирование районов"        },
                new CatalogOperation() { Id = Guid.Parse("f97a4a8d-a007-4156-9f07-d14a635bbb56"), Title = "Редактирование границ районов" },
            });

            public static Catalog ObjectTypeCatalog = new Catalog(WorkingEntities.ObjectTypes.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() { Id = Guid.Parse("003640ae-e1fd-4623-afb3-ef2a4ef5b014"), Title = "Просмотр списка типов"         },
                new CatalogOperation() { Id = Guid.Parse("2eac7ee1-ff6d-45d4-8876-184a2d6381c3"), Title = "Создание типов объектов"       },
                new CatalogOperation() { Id = Guid.Parse("50a5b137-c5cb-4bd3-bc93-1aa3f849ddaf"), Title = "Редактирование типов объектов" },
            });

            public static Catalog TaskTypeCatalog = new Catalog(WorkingEntities.TaskTypes.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() { Id = Guid.Parse("888997c8-fd9d-4b04-8122-80131539d2cb"), Title = "Просмотр списка типов"      },
                new CatalogOperation() { Id = Guid.Parse("8dbd18d9-0253-4829-b113-45bdb65e37bc"), Title = "Создание типов задач"       },
                new CatalogOperation() { Id = Guid.Parse("ed12d9b8-cd59-45d9-8e76-73df71df817f"), Title = "Редактирование типов задач" },
            });

            public static Catalog ResTypeCatalog = new Catalog(WorkingEntities.ResourceTypes.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() { Id = Guid.Parse("718fd2c1-455b-4fb7-b494-cb7b7ed26109"), Title = "Просмотр списка типов"         },
                new CatalogOperation() { Id = Guid.Parse("b5899abf-316c-4100-861a-32e95dc2b722"), Title = "Создание типов ресурсов"       },
                new CatalogOperation() { Id = Guid.Parse("d8679320-8c56-4acc-a83c-160292a64e71"), Title = "Редактирование типов ресурсов" },
            });

            public static Catalog OrgTypeCatalog = new Catalog(WorkingEntities.OrganizationTypes.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() { Id = Guid.Parse("3667d68d-5b92-4905-aec8-bb6ac67e720d"), Title = "Просмотр списка типов"            },
                new CatalogOperation() { Id = Guid.Parse("82e443a5-1a39-44c3-a44a-878c10d4eb6d"), Title = "Создание типов организаций"       },
                new CatalogOperation() { Id = Guid.Parse("f3ff7f7f-995c-4dca-9f3e-eae2b1e16047"), Title = "Редактирование типов организаций" },
            });

            public static Catalog OrgCatalog = new Catalog(WorkingEntities.Organizations.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() { Id = Guid.Parse("b3e5b3a0-734a-44f3-9fd6-011362496b22"), Title = "Просмотр организаций"       },
                new CatalogOperation() { Id = Guid.Parse("14ce3d36-5ce2-46fb-b78f-1c446a349059"), Title = "Создание организаций"       },
                new CatalogOperation() { Id = Guid.Parse("2f71057f-ec97-47c4-8f3c-999b86b874f0"), Title = "Редактирование организаций" },
            });

            public static Catalog UserCatalog = new Catalog(WorkingEntities.Users.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() { Id = Guid.Parse("96f1fbb2-033c-40ce-9801-d028d438d028"), Title = "Просмотр списка пользователей"            },
                new CatalogOperation() { Id = Guid.Parse("41ddfec0-7d9b-437d-9180-c23fcdc7be73"), Title = "Создание пользователей"                   },
                new CatalogOperation() { Id = Guid.Parse("ac75b312-ea4c-4baf-b6da-d42b089ab923"), Title = "Редактирование данных пользователя"       },
                new CatalogOperation() { Id = Guid.Parse("0d32b3f1-be67-40e4-b311-1e856f99d265"), Title = "Редактирование прав доступа пользователя" },
                new CatalogOperation() { Id = Guid.Parse("e3127a00-2fc9-488a-9783-c1c0b40da518"), Title = "Назначение заместителем"                  },
                new CatalogOperation() { Id = Guid.Parse("b417a774-0449-4bbb-8090-4108ac084167"), Title = "Блокировка пользователей"                 },
            });

            public static Catalog RoleCatalog = new Catalog(WorkingEntities.Roles.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() { Id = Guid.Parse("dadfb823-f4b2-4dbb-9564-384eb17d0f21"), Title = "Просмотр списка ролей"       },
                new CatalogOperation() { Id = Guid.Parse("b253c2ac-26e9-41af-b76e-0f84835f4680"), Title = "Просмотр информации о роли"  },
                new CatalogOperation() { Id = Guid.Parse("1c6612f5-d11f-477f-9f48-37969e95b169"), Title = "Создание ролей"              },
                new CatalogOperation() { Id = Guid.Parse("6922be1e-cf19-40e3-b49d-d6c40d8951b7"), Title = "Редактирование ролей"        }
            });
        }
    }
}
