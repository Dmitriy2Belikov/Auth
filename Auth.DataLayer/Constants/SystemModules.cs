using Auth.DataLayer.Models;
using Auth.DataLayer.Models.SystemModules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.Constants
{
    public static class SystemModules
    {
        public static SystemModule Access = new SystemModule() { Id = Guid.Parse("81897513-42aa-444d-b163-ae9139c3e99b"), Title = "Доступ" };
        public static SystemModule Api = new SystemModule() { Id = Guid.Parse("ca61ecb1-344b-4921-9296-2100beb19dc9"), Title = "API" };
        public static SystemModule Auth = new SystemModule() { Id = Guid.Parse("e7e9072a-7d6d-42ff-8a88-e73497feec0e"), Title = "Авторизация" };
        public static SystemModule Catalog = new SystemModule() { Id = Guid.Parse("b469b8e4-1c6b-4a22-b960-547ff45c4c14"), Title = "Справочники" };
        public static SystemModule Tasks = new SystemModule() { Id = Guid.Parse("408e2960-92ca-435e-90d0-31503805e500"), Title = "Задачи" };
        public static SystemModule Resources = new SystemModule() { Id = Guid.Parse("f0a4a40e-4256-451f-b410-f2dcf49991d0"), Title = "Ресурсы" };
        public static SystemModule Reglament = new SystemModule() { Id = Guid.Parse("85a60d1c-e1c3-432d-b222-49dad1d1b999"), Title = "Регламент" };
        public static SystemModule Reports = new SystemModule() { Id = Guid.Parse("1c41231a-23d5-4c9f-a99d-c5d2124afb0a"), Title = "Отчёты" };
        public static SystemModule VehicleMonitoring = new SystemModule() { Id = Guid.Parse("db308ba3-fd09-488b-b776-73f96a2609f6"), Title = "Отслеживание техники" };
        public static SystemModule Quarters = new SystemModule() { Id = Guid.Parse("ac49a788-1ef3-4389-a82e-8d44a7c4405e"), Title = "Квартальные" };
        public static SystemModule Violations = new SystemModule() { Id = Guid.Parse("ffb37f99-35e6-4531-b4a3-3f51059044f9"), Title = "Нарушения" };
        public static SystemModule Knowledge = new SystemModule() { Id = Guid.Parse("65be30e0-3412-4415-9558-f2738e17a08b"), Title = "База знаний" };
        public static SystemModule TrafficLights = new SystemModule() { Id = Guid.Parse("ae023d31-035d-4c96-91b1-d2d70e974cbb"), Title = "Светофоры" };
        public static SystemModule Analytics = new SystemModule() { Id = Guid.Parse("8a2576f0-50bf-48af-82d6-7f8df0439004"), Title = "Аналитика" };
        public static SystemModule ManagerService = new SystemModule() { Id = Guid.Parse("41f12ce6-83c5-4b1f-893c-9c7572a58b58"), Title = "Контроль качества оказания транспортных услуг" };
    }
}
