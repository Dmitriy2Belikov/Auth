using Auth.DataLayer.Models;
using Auth.DataLayer.Models.WorkingEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.Constants
{
    public static class WorkingEntities
    {
          public static WorkingEntity ApiAccess                          = new WorkingEntity() {Id = Guid.Parse("fe12c513-d758-457b-99e0-9db9cbf7b8e2"), Title = "API-общее" };
          public static WorkingEntity Districts                          = new WorkingEntity() {Id = Guid.Parse("bd87a933-48e3-42c5-929a-f654bee0c3be"), Title = "Районы" };
          public static WorkingEntity Streets                            = new WorkingEntity() {Id = Guid.Parse("f0e90e22-a123-4421-83e6-2c59cdcd33f0"), Title = "Улицы" };
          public static WorkingEntity Executors                          = new WorkingEntity() {Id = Guid.Parse("fe8e4a7b-ccfc-438e-8ab1-608a78c93c10"), Title = "Исполнители работ" };
          public static WorkingEntity Objects                            = new WorkingEntity() {Id = Guid.Parse("9e7f2930-c9a4-4eb5-a45d-2bd7aae38733"), Title = "Объекты имущественного комплекса" };
          public static WorkingEntity ObjectParams                       = new WorkingEntity() {Id = Guid.Parse("8b8ce18e-8d46-4cf8-b735-a373cf1b2366"), Title = "Параметры объектов" };
          public static WorkingEntity ObjectCategories                   = new WorkingEntity() {Id = Guid.Parse("2d65a2d8-2a07-4c1e-95b5-873075bc5c05"), Title = "Категории объектов" };
          public static WorkingEntity ObjectTypes                        = new WorkingEntity() {Id = Guid.Parse("8d8cc6cb-f5f7-4298-99d3-0eb96b744821"), Title = "Типы объектов" };
          public static WorkingEntity Organizations                      = new WorkingEntity() {Id = Guid.Parse("f307eb60-049e-46e5-bf71-7ee7ebd8dfca"), Title = "Организации" };
          public static WorkingEntity OrganizationTypes                  = new WorkingEntity() {Id = Guid.Parse("ee294764-1b4d-4f99-b4a5-de3a9516c840"), Title = "Типы организаций" };
          public static WorkingEntity Partners                           = new WorkingEntity() {Id = Guid.Parse("6dceecdc-f883-4bac-94c7-bde11fbda1df"), Title = "Контрагенты" };
          public static WorkingEntity PartnerResponsiblePersons          = new WorkingEntity() {Id = Guid.Parse("bf891464-55fd-424c-ba14-de80724378c7"), Title = "Должностные лица организаций" };
          public static WorkingEntity PartnerTypes                       = new WorkingEntity() {Id = Guid.Parse("0fa676cc-3925-4642-b68d-b5b39201a1b6"), Title = "Типы контрагентов" };
          public static WorkingEntity PlaceCategories                    = new WorkingEntity() {Id = Guid.Parse("72b4adc3-e358-4d98-b6e9-376b2d1438b3"), Title = "Категории мест" };
          public static WorkingEntity PlaceParameters                    = new WorkingEntity() {Id = Guid.Parse("f5b1cbb5-0592-4ee9-a1ff-bcd65b3aa47d"), Title = "Параметры мест" };
          public static WorkingEntity PlaceTypes                         = new WorkingEntity() {Id = Guid.Parse("f222d547-1b2b-4ba4-9e95-dd7056e76d57"), Title = "Типы мест" };
          public static WorkingEntity Resources                          = new WorkingEntity() {Id = Guid.Parse("aefa0c09-ba3a-4a91-9ea7-89928331f857"), Title = "Ресурсы" };
          public static WorkingEntity ResourceTypes                      = new WorkingEntity() {Id = Guid.Parse("49404fd9-8903-4caf-bbce-26b1a790c18b"), Title = "Типы ресурсов" };
          public static WorkingEntity Teams                              = new WorkingEntity() {Id = Guid.Parse("f2cdf9ba-72d5-4521-87b3-ffb025fc0ef7"), Title = "Бригады" };
          public static WorkingEntity Tasks                              = new WorkingEntity() {Id = Guid.Parse("b24af0aa-4033-4d01-a652-8622331f97c0"), Title = "Задачи" };
          public static WorkingEntity TaskTypes                          = new WorkingEntity() {Id = Guid.Parse("f5417d24-f71d-4e51-8c46-1a352b87abd2"), Title = "Типы задач" };
          public static WorkingEntity DefaultTeams                       = new WorkingEntity() {Id = Guid.Parse("67085cfa-af77-44f7-b83d-eaa582c1616f"), Title = "Распределение работ по бригадам" };
          public static WorkingEntity TasksConfiguration                 = new WorkingEntity() {Id = Guid.Parse("ae275c3c-02d5-465d-bee4-28cdef210991"), Title = "Настройки" };
          public static WorkingEntity Materials                          = new WorkingEntity() {Id = Guid.Parse("cb24ead1-71fd-4a4d-a0c0-27680cf65566"), Title = "Материалы" };
          public static WorkingEntity Works                              = new WorkingEntity() {Id = Guid.Parse("e9514213-da76-43ec-a6e9-a5356530ce2c"), Title = "Работы" };
          public static WorkingEntity WorkParams                         = new WorkingEntity() {Id = Guid.Parse("1f85fd79-7117-48bd-8bfe-9d8846f81717"), Title = "Параметры выполненных работ" };
          public static WorkingEntity ViolationArticles                  = new WorkingEntity() {Id = Guid.Parse("36efaad8-80a2-4c6a-9199-1ed4594cacb0"), Title = "Статьи нарушений" };
          public static WorkingEntity ViolationGeneratedDocumentTypes    = new WorkingEntity() {Id = Guid.Parse("f975d5f7-47c7-442a-af26-bef6186faf66"), Title = "Типы формируемых документов" };
          public static WorkingEntity ViolationTypes                     = new WorkingEntity() {Id = Guid.Parse("eeb3cc1e-c405-4c59-b32d-1f6f367bcfc9"), Title = "Типы нарушений" };
          public static WorkingEntity Year                               = new WorkingEntity() {Id = Guid.Parse("72d30852-b183-4300-931c-67cd9ba6aa9a"), Title = "Год" };
          public static WorkingEntity QuartersConfiguration              = new WorkingEntity() {Id = Guid.Parse("cdca62fa-1407-4536-b413-7019450fea64"), Title = "Настройки" };
          public static WorkingEntity Inspectors                         = new WorkingEntity() {Id = Guid.Parse("2bc701b8-8d61-40cf-bd58-3676579c1b0a"), Title = "Квартальные" };
          public static WorkingEntity QuarterTerritories                 = new WorkingEntity() {Id = Guid.Parse("0d4018a3-b572-43ca-868f-cf3eac6cfbbe"), Title = "Имущественные комплексы" };
          public static WorkingEntity Roles                              = new WorkingEntity() {Id = Guid.Parse("2ee5332a-1901-4ca7-b71f-12063201dee6"), Title = "Роли" };
          public static WorkingEntity Users                              = new WorkingEntity() {Id = Guid.Parse("2e499657-73f8-4380-a727-7f1b20eee095"), Title = "Пользователи" };
          public static WorkingEntity Reports                            = new WorkingEntity() {Id = Guid.Parse("21676c4c-7264-4986-8ef3-78f29d0dd1ec"), Title =  "Отчёты" };
          public static WorkingEntity VehicleMonitoring                  = new WorkingEntity() {Id = Guid.Parse("e9631220-dc0b-462f-a7df-e44f611a118d"), Title = "Отслеживание техники" };
          public static WorkingEntity Violations                         = new WorkingEntity() {Id = Guid.Parse("06c35f48-2a83-4ef4-b962-9f2ebf8b2b15"), Title = "Нарушения" };
          public static WorkingEntity QuarterReports                     = new WorkingEntity() {Id = Guid.Parse("f64eda70-d887-4788-b7fa-d8c9de70c195"), Title =  "Отчёты" };
          public static WorkingEntity TrafficLightsViolations            = new WorkingEntity() {Id = Guid.Parse("733ae7ec-1c52-49b2-955e-87ee41b81dee"), Title =  "Нарушения раздела 'Светофоры'" };
          public static WorkingEntity KnowledgeArticle                   = new WorkingEntity() {Id = Guid.Parse("e8fcc673-5eeb-48a2-8cab-f868c9657ce9"), Title = "Статьи базы знаний модуля 'Квартальные'" };
          public static WorkingEntity KnowledgeArticleScope              = new WorkingEntity() {Id = Guid.Parse("e0519177-4441-496a-8811-cf438db8a974"), Title = "Разделы базы знаний модуля 'Квартальные'" };
          public static WorkingEntity AnalyticsReports                   = new WorkingEntity() {Id = Guid.Parse("6f1180af-7051-4c84-b40c-08254f3cb91c"), Title = "Отчёты раздела 'Квартальные'"};
          public static WorkingEntity MaterialTypes                      = new WorkingEntity() {Id = Guid.Parse("956af268-f408-4eba-9e52-c910f423b2f7"), Title = "Типы материалов" };
          public static WorkingEntity Specializations                    = new WorkingEntity() {Id = Guid.Parse("4be627e6-a8c8-413d-8b95-0d521937a802"), Title = "Специализации" };
          public static WorkingEntity TrafficObjectsTypes                = new WorkingEntity() {Id = Guid.Parse("782e07d6-11d3-46fd-b171-968f596179f0"), Title = "Типы объектов" };
          public static WorkingEntity ViolationCauses                    = new WorkingEntity() {Id = Guid.Parse("ec65b7ef-47de-4390-beb4-fc202b01273d"), Title = "Причины нарушений" };
          public static WorkingEntity TrafficViolationsTypes             = new WorkingEntity() {Id = Guid.Parse("1389c933-85d9-4ec3-be31-66d85852c4a4"), Title = "Типы нарушений"  };
          public static WorkingEntity Workers                            = new WorkingEntity() {Id = Guid.Parse("ae4ebc9d-4197-4e62-895d-5b8b5f8818bd"), Title = "Специалисты" };
          public static WorkingEntity Requests                           = new WorkingEntity() {Id = Guid.Parse("6aaeb2d1-0b44-45e4-8158-31dbf7f919dc"), Title = "Заявки" };
          public static WorkingEntity Brigades                           = new WorkingEntity() {Id = Guid.Parse("020842a2-3d42-47bf-a31d-7d89d58a8e31"), Title = "Бригады" };
          public static WorkingEntity KotuReports                        = new WorkingEntity() {Id = Guid.Parse("146b254c-5b16-47f3-b9a2-147e0dcc5a1a"), Title = "Отчеты" };
          public static WorkingEntity AutoPark                           = new WorkingEntity() {Id = Guid.Parse("44fd9f29-1b69-4701-bbd3-05c26abade85"), Title = "Автопарк" };
          public static WorkingEntity TrafficLightObjects                = new WorkingEntity() {Id = Guid.Parse("109b5c9a-6fa9-41b6-8d34-d01745f6368c"), Title = "Светофорные объекты" };
          public static WorkingEntity QRCode                             = new WorkingEntity() {Id = Guid.Parse("c89297a9-a990-4695-b92a-324b3cb92495"), Title = "QR-коды" };

    }                                         
}                                             
                                              
                                              
                                              