using Auth.DataLayer;
using Auth.DataLayer.ConfigurationModules;
using Auth.DataLayer.Constants;
using Auth.DataLayer.Enums;
using Auth.DataLayer.Models;
using Auth.Services.PrimitivesServices.RoleServices;
using Auth.Services.PrimitivesServices.UserServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Auth.Services.SeedServices
{
    public static class ContextManager
    {
        public static void AddOrUpdate<T>(DbContext context, IEnumerable<T> data)
            where T : class
        {
            DbSet<T> entities = context.Set<T>();

            foreach (var entity in data)
            {
                if (!entities.Any(e => e == entity))
                {
                    entities.Add(entity);
                    context.SaveChanges();
                }
                else
                {
                    entities.Update(entity);
                    context.SaveChanges();
                }
            }
        }
    }

    public class SeedService : ISeedService
    {
        private UserDbContext _context;
        private IRoleService _roleService;
        private IUserService _userService;

        public SeedService(UserDbContext context, IRoleService roleService, IUserService userService)
        {
            _context = context;
            _roleService = roleService;
            _userService = userService;
        }

        public void Configure()
        {
            ContextManager.AddOrUpdate(_context, GetDefaultRoles());
            ContextManager.AddOrUpdate(_context, GetDefaultUsers());
            ContextManager.AddOrUpdate(_context, GetDefaultPersons());
            ContextManager.AddOrUpdate(_context, GetDefaultUserRoleLinks());

            ContextManager.AddOrUpdate(_context, GetDefaultRules());

            ContextManager.AddOrUpdate(_context, GetDefaultSystemModules());
            ContextManager.AddOrUpdate(_context, GetDefaultRoleSystemModuleLinks());

            ContextManager.AddOrUpdate(_context, GetDefaultWorkingEntities());
            ContextManager.AddOrUpdate(_context, GetDefaultWorkingEntityOperations());

            ContextManager.AddOrUpdate(_context, GetDefaultPermissions());

            ContextManager.AddOrUpdate(_context, GetDefaultOrganizationTypes());
            ContextManager.AddOrUpdate(_context, GetDefaultOrganizations());
            ContextManager.AddOrUpdate(_context, GetOrganizationRequisites());
        }

        private IEnumerable<Role> GetDefaultRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Id = Root.RootRoleId,
                    Name = "SuperAdmin"
                }
            };

            return roles;
        }

        private IEnumerable<User> GetDefaultUsers()
        {
            var users = new List<User>()
            {
                new User()
                {
                    Id = Root.RootUserId,
                    Login = "root",
                    Password = Helpers.HashPassword("admin")
                }
            };

            return users;
        }

        private IEnumerable<Person> GetDefaultPersons()
        {
            var persons = new List<Person>()
            {
                new Person()
                {
                    Id = Guid.Parse("61b2fe7f-f48f-4ab8-b45c-2cdd3da707a7"),
                    LastName = "Супер",
                    FirstName = "Администратор",
                    SurName = null,
                    Gender = Genders.Male,
                    BirthDate = new DateTime(1991, 1, 1),
                    Snils = "111-111-111-45"
                }
            };

            return persons;
        }

        private IEnumerable<UserRoleLink> GetDefaultUserRoleLinks()
        {
            var userRoles = new List<UserRoleLink>()
            {
                new UserRoleLink()
                {
                    RoleId = Root.RootRoleId,
                    UserId = Root.RootUserId
                }
            };

            return userRoles;
        }

        private IEnumerable<Rule> GetDefaultRules()
        {
            var rules = new List<Rule>()
            {
                Rules.Nothing,
                Rules.AllOrganizations
            };

            return rules;
        }

        private IEnumerable<Permission> GetDefaultPermissions()
        {
            var workingEntityOperations = GetDefaultWorkingEntityOperations();

            var permissions = new List<Permission>();

            foreach (var workingEntityOperation in workingEntityOperations)
            {
                var permission = new Permission()
                {
                    WorkingEntityOperationId = workingEntityOperation.Id,
                    RoleId = Root.RootRoleId,
                    RuleId = Rules.AllOrganizations.Id
                };

                permissions.Add(permission);
            }

            return permissions;
        }

        private IEnumerable<SystemModule> GetDefaultSystemModules()
        {
            var systemModules = new List<SystemModule>()
            {
                SystemModules.Access                  ,
                SystemModules.Api                     ,
                SystemModules.Auth                    ,
                SystemModules.Catalog                 ,
                SystemModules.Tasks                   ,
                SystemModules.Resources               ,
                SystemModules.Reglament               ,
                SystemModules.Reports                 ,
                SystemModules.VehicleMonitoring       ,
                SystemModules.Quarters                ,
                SystemModules.Violations              ,
                SystemModules.Knowledge               ,
                SystemModules.TrafficLights           ,
                SystemModules.Analytics               ,
                SystemModules.ManagerService
            };

            return systemModules;
        }

        private IEnumerable<RoleSystemModuleLink> GetDefaultRoleSystemModuleLinks()
        {
            var roleSystemModuleLinks = GetDefaultSystemModules()
                .Select(s => new RoleSystemModuleLink() { RoleId = Root.RootRoleId, SystemModuleId = s.Id });

            return roleSystemModuleLinks;
        }

        private IEnumerable<WorkingEntity> GetDefaultWorkingEntities()
        {
            var workingEntities = new List<WorkingEntity>()
            {
                WorkingEntities.ApiAccess                      ,
                WorkingEntities.Districts                      ,
                WorkingEntities.Streets                        ,
                WorkingEntities.Executors                      ,
                WorkingEntities.Objects                        ,
                WorkingEntities.ObjectParams                   ,
                WorkingEntities.ObjectCategories               ,
                WorkingEntities.ObjectTypes                    ,
                WorkingEntities.Organizations                  ,
                WorkingEntities.OrganizationTypes              ,
                WorkingEntities.Partners                       ,
                WorkingEntities.PartnerResponsiblePersons      ,
                WorkingEntities.PartnerTypes                   ,
                WorkingEntities.PlaceCategories                ,
                WorkingEntities.PlaceParameters                ,
                WorkingEntities.PlaceTypes                     ,
                WorkingEntities.Resources                      ,
                WorkingEntities.ResourceTypes                  ,
                WorkingEntities.Teams                          ,
                WorkingEntities.Tasks                          ,
                WorkingEntities.TaskTypes                      ,
                WorkingEntities.DefaultTeams                   ,
                WorkingEntities.TasksConfiguration             ,
                WorkingEntities.Materials                      ,
                WorkingEntities.Works                          ,
                WorkingEntities.WorkParams                     ,
                WorkingEntities.ViolationArticles              ,
                WorkingEntities.ViolationGeneratedDocumentTypes,
                WorkingEntities.ViolationTypes                 ,
                WorkingEntities.Year                           ,
                WorkingEntities.QuartersConfiguration          ,
                WorkingEntities.Inspectors                     ,
                WorkingEntities.QuarterTerritories             ,
                WorkingEntities.Roles                          ,
                WorkingEntities.Users                          ,
                WorkingEntities.Reports                        ,
                WorkingEntities.VehicleMonitoring              ,
                WorkingEntities.Violations                     ,
                WorkingEntities.QuarterReports                 ,
                WorkingEntities.TrafficLightsViolations        ,
                WorkingEntities.KnowledgeArticle               ,
                WorkingEntities.KnowledgeArticleScope          ,
                WorkingEntities.AnalyticsReports               ,
                WorkingEntities.MaterialTypes                  ,
                WorkingEntities.Specializations                ,
                WorkingEntities.TrafficObjectsTypes            ,
                WorkingEntities.ViolationCauses                ,
                WorkingEntities.TrafficViolationsTypes         ,
                WorkingEntities.Workers                        ,
                WorkingEntities.Requests                       ,
                WorkingEntities.Brigades                       ,
                WorkingEntities.KotuReports                    ,
                WorkingEntities.AutoPark                       ,
                WorkingEntities.TrafficLightObjects            ,
                WorkingEntities.QRCode
            };

            return workingEntities;
        }

        private IEnumerable<WorkingEntityOperation> GetDefaultWorkingEntityOperations()
        {
            var workingEntityOperations = new List<WorkingEntityOperation>();

            workingEntityOperations.AddRange(SeedForModule(AccessAppConfig.Instance));
            workingEntityOperations.AddRange(SeedForModule(AnalyticsAppConfig.Instance));
            workingEntityOperations.AddRange(SeedForModule(ApiAppConfig.Instance));
            workingEntityOperations.AddRange(SeedForModule(AuthorizationAppConfig.Instance));
            workingEntityOperations.AddRange(SeedForModule(CatalogAppConfig.Instance));
            workingEntityOperations.AddRange(SeedForModule(KnowledgeAppConfig.Instance));
            workingEntityOperations.AddRange(SeedForModule(KotuManagerServiceAppConfig.Instance));
            workingEntityOperations.AddRange(SeedForModule(QuartersAppConfig.Instance));
            workingEntityOperations.AddRange(SeedForModule(ReglamentAppConfig.Instance));
            workingEntityOperations.AddRange(SeedForModule(ReportsAppConfig.Instance));
            workingEntityOperations.AddRange(SeedForModule(ResourceAppConfig.Instance));
            workingEntityOperations.AddRange(SeedForModule(TasksAppConfig.Instance));
            workingEntityOperations.AddRange(SeedForModule(TrafficLightsAppConfig.Instance));
            workingEntityOperations.AddRange(SeedForModule(VehicleMonitoringAppConfig.Instance));
            workingEntityOperations.AddRange(SeedForModule(ViolationsAppConfig.Instance));

            return workingEntityOperations;
        }

        private List<WorkingEntityOperation> SeedForModule(IModuleConfig moduleConfig)
        {
            var workingEntityOperations = moduleConfig.Catalogs
                .SelectMany(c => c.Operations.Select(o => new WorkingEntityOperation()
                {
                    Id = o.Id,
                    Title = o.Title,
                    SystemModuleId = moduleConfig.SystemModuleId,
                    WorkingEntityId = c.WorkingEntityId
                }))
                .ToList();

            return workingEntityOperations;
        }

        private IEnumerable<OrganizationType> GetDefaultOrganizationTypes()
        {
            var organizationTypes = new List<OrganizationType>()
            {
                new OrganizationType()
                {
                    Id = Guid.Parse("6912678f-7ce6-4e75-bad9-f081ef996a1f"),
                    Title = "Административная организация"
                },
                new OrganizationType()
                {
                    Id = Guid.Parse("b3c243c7-36fc-4fec-9a4d-3747dfe13cd1"),
                    Title = "ДЭУ"
                },
                new OrganizationType()
                {
                    Id = Guid.Parse("58166f3b-81fd-428d-8869-486620f8b76a"),
                    Title = "Центр организации движения"
                },
                new OrganizationType()
                {
                    Id = Guid.Parse("76a8d286-58c0-4ea1-adc2-775ffee81204"),
                    Title = "Перевозчики"
                }
            };

            return organizationTypes;
        }

        private IEnumerable<Organization> GetDefaultOrganizations()
        {
            var organizations = new List<Organization>()
            {
                new Organization()
                {
                    Id = Root.EkadmId,
                    OrganizationTypeId = Guid.Parse("6912678f-7ce6-4e75-bad9-f081ef996a1f"),
                    Title = "Администрация города Екатеринбурга",
                    TitleShort = "АГЕ",
                    ParentOrganizationId = null
                }
            };

            return organizations;
        }

        private IEnumerable<OrganizationRequisite> GetOrganizationRequisites()
        {
            var organizationRequisites = new List<OrganizationRequisite>()
            {
                new OrganizationRequisite()
                {
                    OrganizationId = Root.EkadmId,
                    LegalAddress = "Ленина 24",
                    PostAddress = "Ленина 24"
                }
            };

            return organizationRequisites;
        } 
    }
}
