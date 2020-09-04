using Auth.DataLayer.ConfigurationModules.Common;
using Auth.DataLayer.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.ConfigurationModules
{
    public class KotuManagerServiceAppConfig : IModuleConfig
    {
        private static Lazy<KotuManagerServiceAppConfig> _instance = new Lazy<KotuManagerServiceAppConfig>(() => new KotuManagerServiceAppConfig());

        public static KotuManagerServiceAppConfig Instance = _instance.Value;

        public Guid SystemModuleId { get; }
        public List<Catalog> Catalogs { get; }

        public KotuManagerServiceAppConfig()
        {
            SystemModuleId = SystemModules.ManagerService.Id;

            Catalogs = new List<Catalog>()
            {
                KotuManagerServiceAppCatalogs.KotuManagerServiceMaterialTypesCatalog ,
                KotuManagerServiceAppCatalogs.KotuManagerServiceSpecializationsCatalog ,
                KotuManagerServiceAppCatalogs.KotuManagerServiceTrafficObjectsTypesCatalog ,
                KotuManagerServiceAppCatalogs.KotuManagerServiceTrafficViolationsTypesCatalog ,
                KotuManagerServiceAppCatalogs.KotuManagerServiceViolationCausesCatalog ,
                KotuManagerServiceAppCatalogs.KotuManagerServiceWorkersCatalog ,
                KotuManagerServiceAppCatalogs.KotuManagerServiceRequestsCatalog ,
                KotuManagerServiceAppCatalogs.KotuManagerServiceBrigadeCatalog ,
                KotuManagerServiceAppCatalogs.KotuManagerServiceAutoParkCatalog ,
                KotuManagerServiceAppCatalogs.KotuManagerServiceKotuReportCatalog ,
                KotuManagerServiceAppCatalogs.KotuManagerServiceTrafficLightObjectCatalog ,
                KotuManagerServiceAppCatalogs.KotuManagerServiceQRCodeCatalog
            };
        }

        private static class KotuManagerServiceAppCatalogs
        {
            public static Catalog KotuManagerServiceMaterialTypesCatalog = new Catalog(WorkingEntities.MaterialTypes.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() {Id = Guid.Parse("9f8d6c64-a54c-4d33-913f-386e8a057eac"), Title = "Просмотр типов материалов"      },
                new CatalogOperation() {Id = Guid.Parse("d298a8e9-7635-40ab-8f3a-b02d6737c116"), Title = "Создание типов материалов"      },
                new CatalogOperation() {Id = Guid.Parse("2896178f-5862-4011-8850-f1afdbfd0560"), Title = "Редактирование типов материалов"},
                new CatalogOperation() {Id = Guid.Parse("e7226706-8a0f-43f4-b2b2-27125838ec76"), Title = "Деактивация типов материалов"   },
            });

            public static Catalog KotuManagerServiceSpecializationsCatalog = new Catalog(WorkingEntities.Specializations.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() {Id = Guid.Parse("8ff60e9c-a4f4-479a-8b43-a92c54474fab"), Title = "Просмотр специализаций"      },
                new CatalogOperation() {Id = Guid.Parse("bb8fbd72-69e0-4b9f-984c-d74d69c54a66"), Title = "Создание специализаций"      },
                new CatalogOperation() {Id = Guid.Parse("37d57cdf-361f-4c40-bdef-d78efdbaec0e"), Title = "Редактирование специализаций"},
                new CatalogOperation() {Id = Guid.Parse("4ad8ea66-ea8a-4606-8fd1-40939eb4deae"), Title = "Деактивация специализаций"   },
            });

            public static Catalog KotuManagerServiceTrafficObjectsTypesCatalog = new Catalog(WorkingEntities.TrafficObjectsTypes.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() {Id = Guid.Parse("bf171b9b-bb80-4c79-85a0-b9282bca1448"), Title = "Просмотр типов объекта"      },
                new CatalogOperation() {Id = Guid.Parse("69a62448-6d9d-4fa8-9974-2fd1228b9035"), Title = "Создание типов объекта"      },
                new CatalogOperation() {Id = Guid.Parse("39205c8b-4f86-4c26-a096-70908816c276"), Title = "Редактирование типов объекта"},
                new CatalogOperation() {Id = Guid.Parse("49d07e9a-990f-4ec8-ac10-62e092a877b1"), Title = "Деактивация типов объекта"   },
            });

            public static Catalog KotuManagerServiceTrafficViolationsTypesCatalog = new Catalog(WorkingEntities.TrafficViolationsTypes.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() {Id = Guid.Parse("5a5b98bd-d757-4b0b-8b74-30388c5490a4"), Title = "Просмотр типов нарушений"      },
                new CatalogOperation() {Id = Guid.Parse("046c0204-cbba-415d-894f-6e1e105d6679"), Title = "Создание типов нарушений"      },
                new CatalogOperation() {Id = Guid.Parse("50a6bcf7-87e2-444a-b0f3-aa470d4c37cd"), Title = "Редактирование типов нарушений"},
                new CatalogOperation() {Id = Guid.Parse("475baf1e-bcd1-4403-be02-28615bae32b6"), Title = "Деактивация типов нарушений"   },
            });

            public static Catalog KotuManagerServiceViolationCausesCatalog = new Catalog(WorkingEntities.ViolationCauses.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() {Id = Guid.Parse("345fc2f6-a2ac-44ad-914b-3e10e5f1fc35"), Title = "Просмотр причин нарушений"      },
                new CatalogOperation() {Id = Guid.Parse("a68c3e5c-fe03-4e41-b342-e56fd3dadbd8"), Title = "Создание причин нарушений"      },
                new CatalogOperation() {Id = Guid.Parse("b31bd70f-be16-449d-9d8e-92601a7461e0"), Title = "Редактирование причин нарушений"},
                new CatalogOperation() {Id = Guid.Parse("dffd5004-813c-4901-a0f0-46ed111450df"), Title = "Деактивация причин нарушений"   },
            });

            public static Catalog KotuManagerServiceWorkersCatalog = new Catalog(WorkingEntities.Workers.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() {Id = Guid.Parse("dc54b0d5-8586-4cfd-bbc2-7b29c02f9235"), Title = "Просмотр специалистов"      },
                new CatalogOperation() {Id = Guid.Parse("893936ad-034c-4e0e-bdea-5001fb4c2a58"), Title = "Создание специалистов"      },
                new CatalogOperation() {Id = Guid.Parse("e0fcadf9-48de-4cfd-9e3a-1acdbc3787f1"), Title = "Редактирование специалистов"},
                new CatalogOperation() {Id = Guid.Parse("0e6d5126-937f-4d2e-9b54-93c346bc02ea"), Title = "Деактивация специалистов"   },
            });

            public static Catalog KotuManagerServiceRequestsCatalog = new Catalog(WorkingEntities.Requests.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() {Id = Guid.Parse("17a1dd48-067f-4e03-8a92-e3edd075e2b8"), Title = "Просмотр заявок"                },
                new CatalogOperation() {Id = Guid.Parse("167681c8-6a9d-4219-95f4-ef9b5238332e"), Title = "Создание заявок"                },
                new CatalogOperation() {Id = Guid.Parse("d27d13fe-9997-4400-b8ee-52a92160e596"), Title = "Редактирование заявок"          },
                new CatalogOperation() {Id = Guid.Parse("d132b8c6-8a57-4e83-8569-da5333e0c5ce"), Title = "Закрытие заявок"                },
                new CatalogOperation() {Id = Guid.Parse("3f19a431-72d1-46f6-8559-3bd77642c454"), Title = "Отклонение заявок"              },
                new CatalogOperation() {Id = Guid.Parse("d77e794c-ad35-4608-9571-a1fa525422f1"), Title = "Назначение бригады на заявку"   },
                new CatalogOperation() {Id = Guid.Parse("a326943d-f621-4cd8-90a2-b7338c0bcaf6"), Title = "Взятие заявки в работу"         },
                new CatalogOperation() {Id = Guid.Parse("ae455b3f-f3b5-4e27-a98c-7e87435d5cdd"), Title = "Просмотр истории заявок"        },
                new CatalogOperation() {Id = Guid.Parse("21428b4d-b818-4aca-be63-e5bc4931c0fe"), Title = "Просмотр адресанта заявок"      },
                new CatalogOperation() {Id = Guid.Parse("ae80779b-c10c-47c0-9014-b8a87b327b4b"), Title = "Просмотр запланированных заявок"},
                new CatalogOperation() {Id = Guid.Parse("0398db77-5f3a-43b6-babd-2d41bb522279"), Title = "Публикация новых заявок"        },
                new CatalogOperation() {Id = Guid.Parse("0c4f4fde-9623-47ae-91d9-93dcd400d0d1"), Title = "Чат с заявителем"               },
            });

            public static Catalog KotuManagerServiceBrigadeCatalog = new Catalog(WorkingEntities.Brigades.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() {Id = Guid.Parse("02f1e9ca-5a4d-4449-ac33-6e2c385f0da5"), Title = "Просмотр бригад"      },
                new CatalogOperation() {Id = Guid.Parse("871b6fad-7421-41d7-b12f-65ec4bf370bd"), Title = "Создание бригад"      },
                new CatalogOperation() {Id = Guid.Parse("a2298d69-0121-42a3-811c-048c5de86632"), Title = "Редактирование бригад"},
                new CatalogOperation() {Id = Guid.Parse("dd222f51-79ae-4997-a895-233789b2a87b"), Title = "Деактивация бригад"   },
            });

            public static Catalog KotuManagerServiceAutoParkCatalog = new Catalog(WorkingEntities.AutoPark.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() {Id = Guid.Parse("ae991230-d650-45d4-bed2-5a2d2627d61b"), Title = "Просмотр автопарка"      },
                new CatalogOperation() {Id = Guid.Parse("c58f5f84-47a8-48ff-bbed-da2744152c72"), Title = "Редактирование автопарка"},
            });

            public static Catalog KotuManagerServiceKotuReportCatalog = new Catalog(WorkingEntities.KotuReports.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() {Id = Guid.Parse("bee5ff42-5120-4ffa-8f32-c08b44b47a34"), Title = "Выгрузка отчетов"},
            });

            public static Catalog KotuManagerServiceTrafficLightObjectCatalog = new Catalog(WorkingEntities.TrafficLightObjects.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() {Id = Guid.Parse("6d3627e9-3c91-470b-b9ff-a9d2bfd17335"), Title = "Просмотр светофорных объектов"      },
                new CatalogOperation() {Id = Guid.Parse("5745fedb-ca6c-48da-9824-606e10d686e6"), Title = "Создание светофорных объектов"      },
                new CatalogOperation() {Id = Guid.Parse("5b056557-cc66-4689-9436-2aa3470efec6"), Title = "Редактирование светофорных объектов"},
                new CatalogOperation() {Id = Guid.Parse("02a7694d-82e7-4e25-bb2a-b300e0183f6e"), Title = "Деактивация светофорных объектов"   },
            });

            public static Catalog KotuManagerServiceQRCodeCatalog = new Catalog(WorkingEntities.QRCode.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() {Id = Guid.Parse("c89297a9-a990-4695-b92a-324b3cb92495"), Title = "Выгрузка QR-кодов"   },
            });
        }
    }
}
