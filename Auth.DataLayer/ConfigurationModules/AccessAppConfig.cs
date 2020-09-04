using Auth.DataLayer.ConfigurationModules.Common;
using Auth.DataLayer.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.ConfigurationModules
{
    public class AccessAppConfig : IModuleConfig
    {
        private static Lazy<AccessAppConfig> _instance = new Lazy<AccessAppConfig>(() => new AccessAppConfig());

        public static AccessAppConfig Instance = _instance.Value;

        public Guid SystemModuleId { get; }
        public List<Catalog> Catalogs { get; }

        private AccessAppConfig()
        {
            SystemModuleId = SystemModules.Access.Id;

            Catalogs = new List<Catalog>()
            {
                AccessAppCatalogs.UserCatalog,
                AccessAppCatalogs.RoleCatalog
            };
        }

        private static class AccessAppCatalogs
        {
            public static Catalog UserCatalog = new Catalog(WorkingEntities.Users.Id, new List<CatalogOperation>()
                {
                    new CatalogOperation() { Id = Guid.Parse("06eab222-366a-483b-b57e-1bb8be209b1a"), Title = "Просмотр списка пользователей" },
                    new CatalogOperation() { Id = Guid.Parse("b6a8f9ca-6a7b-42aa-a3dd-f5cb02727967"), Title = "Создание пользователей" },
                    new CatalogOperation() { Id = Guid.Parse("267f17fc-b779-46f2-a63f-9d555d838d8f"), Title = "Редактирование данных пользователя" },
                    new CatalogOperation() { Id = Guid.Parse("c5733443-3097-449d-9c1e-ef3b57b3b026"), Title = "Редактирование прав доступа пользователя" },
                    new CatalogOperation() { Id = Guid.Parse("6e0220b9-5c9c-4a7a-96d7-f8ebd550aeee"), Title = "Назначение заместителем" },
                    new CatalogOperation() { Id = Guid.Parse("e98a4c36-c7eb-49f0-be7e-9f1889f60238"), Title = "Блокировка пользователей" }
                });

            public static Catalog RoleCatalog = new Catalog(WorkingEntities.Roles.Id, new List<CatalogOperation>()
                {
                    new CatalogOperation() { Id = Guid.Parse("d88202d4-be6c-4742-ba47-d24118ab6dc7"), Title = "Просмотр списка ролей" },
                    new CatalogOperation() { Id = Guid.Parse("5cdf21a8-4f45-4914-b43d-b773bf180d4e"), Title = "Просмотр информации о роли" },
                    new CatalogOperation() { Id = Guid.Parse("d08151e1-3470-4f32-8f02-b128aa3b8825"), Title = "Создание ролей" },
                    new CatalogOperation() { Id = Guid.Parse("e9d2e02f-f526-4e60-9769-1484bd7a4939"), Title = "Редактирование ролей" }
                });
        }
    }
}
