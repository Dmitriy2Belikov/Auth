using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Auth.DataLayer.ConfigurationModules.Common
{
    public static class CatalogOperations
    {
        // AuthorizationAppConfig

        // CatalogAppConfig

        /* PartnerResponsiblePersonConfig */
        public static CatalogOperation PartnerResponsiblePersonView => new CatalogOperation() { Id = Guid.Parse("8f78d63f-ff11-4dd5-8205-d7b4d653abf0"), Title = "Просмотр должностных лиц" };
        public static CatalogOperation PartnerResponsiblePersonCreate => new CatalogOperation() { Id = Guid.Parse("0870ff5a-d73a-4083-992c-e92c3ec48eb1"), Title = "Создание должностных лиц" };
        public static CatalogOperation PartnerResponsiblePersonEdit => new CatalogOperation() { Id = Guid.Parse("afc515cf-3219-4791-8eec-a64a21bd8d95"), Title = "Редактирование должностных лиц" };

        /* ViolationArticlesConfig */
        public static CatalogOperation View => new CatalogOperation() { Id = Guid.Parse("f3f79333-ad8d-43a7-903c-b7310a1b2d3d"), Title = "Просмотр списка статей" };
        public static CatalogOperation Create => new CatalogOperation() { Id = Guid.Parse("0ceed451-a8a6-4986-b1de-c501dbf3b204"), Title = "Создание статей" };
        public static CatalogOperation Edit => new CatalogOperation() { Id = Guid.Parse("a127e79b-42aa-41c0-81ed-4c1da1d3a814"), Title = "Редактирование статей" };
        public static CatalogOperation Delete => new CatalogOperation() { Id = Guid.Parse("7e9c878b-7d20-433c-8bdb-3979c88825d9"), Title = "Удаление статей" };
    }
}
