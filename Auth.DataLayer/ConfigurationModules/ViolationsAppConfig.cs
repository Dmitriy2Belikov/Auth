using Auth.DataLayer.ConfigurationModules.Common;
using Auth.DataLayer.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.ConfigurationModules
{
    public class ViolationsAppConfig : IModuleConfig
    {
        private static Lazy<ViolationsAppConfig> _instance = new Lazy<ViolationsAppConfig>(() => new ViolationsAppConfig());

        public static ViolationsAppConfig Instance = _instance.Value;

        public Guid SystemModuleId { get; }
        public List<Catalog> Catalogs { get; }

        public ViolationsAppConfig()
        {
            SystemModuleId = SystemModules.Violations.Id;

            Catalogs = new List<Catalog>()
            {
                ViolationsAppCatalogs.ViolationsViolationCatalog
            };
        }

        private static class ViolationsAppCatalogs
        {
            public static Catalog ViolationsViolationCatalog = new Catalog(WorkingEntities.Violations.Id, new List<CatalogOperation>()
            {
                new CatalogOperation() {Id = Guid.Parse("c8acced2-f572-45ce-a79c-925bb9e9367e"), Title = "Просмотр назначенных на ИК нарушений"   },
                new CatalogOperation() {Id = Guid.Parse("de99ae58-0d3b-41a0-a0ef-2954bbb3a800"), Title = "Просмотр нарушений без определенного ИК"},
                new CatalogOperation() {Id = Guid.Parse("93925e81-e7c3-4265-a34c-56f2c00eb5e7"), Title = "Просмотр архива нарушений"              },
                new CatalogOperation() {Id = Guid.Parse("f76f4127-c9db-41ad-bc2f-bc6e9300c713"), Title = "Создание нарушений"                     },
                new CatalogOperation() {Id = Guid.Parse("2c947fe0-90c1-4c39-9916-965894cc015c"), Title = "Редактирование основной информации"     },
                new CatalogOperation() {Id = Guid.Parse("5881c8ff-f676-4d39-a8f2-828292d3c060"), Title = "Взятие нарушения в работу"              },
                new CatalogOperation() {Id = Guid.Parse("36abb4d6-aec2-4a6e-b07a-2a2d6e96613a"), Title = "Отмена взятия нарушения в работу"       },
                new CatalogOperation() {Id = Guid.Parse("e95e0e4d-0468-4695-b9b1-9928c5c339ad"), Title = "Комментирование нарушений"              },
                new CatalogOperation() {Id = Guid.Parse("73a24034-fc07-455b-9a1c-63af650f6712"), Title = "Модерирование комментариев"             },
                new CatalogOperation() {Id = Guid.Parse("105c7de5-ab14-41f5-9db0-c5e7ceb87114"), Title = "Вынесение решения"                      },
                new CatalogOperation() {Id = Guid.Parse("03f74c65-7f11-453c-be9e-312ae5fa431c"), Title = "Аннулирование привязки к ИК"            },
                new CatalogOperation() {Id = Guid.Parse("23438685-09b7-4bba-81eb-959e7c0a44c1"), Title = "Назначение ИК/инспекторов"              },
                new CatalogOperation() {Id = Guid.Parse("55f235d6-2eb9-47d9-a9f6-6a143979ce7c"), Title = "Отклонение нарушения"                   },
                new CatalogOperation() {Id = Guid.Parse("9b04a1d7-3bbb-41c6-8bb8-acafb96b883a"), Title = "Отмена отклонения нарушения"            },
                new CatalogOperation() {Id = Guid.Parse("e9a79544-dfe4-491a-8cbb-3493b5a22497"), Title = "Добавление документов"                  },
                new CatalogOperation() {Id = Guid.Parse("3945731c-e244-4228-bb6e-991855e9d950"), Title = "Закрытие нарушения"                     },
                new CatalogOperation() {Id = Guid.Parse("07a71052-4ab3-4673-89e9-b80216f92592"), Title = "Отмена закрытия нарушения"              },
            });
        }
    }
}
