using Auth.DataLayer.Models;
using Auth.DataLayer.Repositories.ModelRepos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Auth.DataLayer.Repositories.RoleSystemModuleRepos
{
    public class RoleSystemModuleLinkRepository : ModelRepository<RoleSystemModuleLink>, IRoleSystemModuleLinkRepository
    {
        private UserDbContext _context;

        public RoleSystemModuleLinkRepository(UserDbContext context) : base(context)
        {
            _context = context;
        }

        public SystemModule GetSystemModule(Guid roleId, Guid systemModuleId)
        {
            var systemModule = _context.RoleSystemModuleLinks.Find(roleId, systemModuleId).SystemModule;

            return systemModule;
        }

        public IEnumerable<SystemModule> GetAllSystemModulesByRoleId(Guid roleId)
        {
            var systemModules = _context.RoleSystemModuleLinks
                .Include(s => s.SystemModule)
                .Where(r => r.RoleId == roleId)
                .Select(sm => sm.SystemModule);

            return systemModules;
        }

        public IEnumerable<RoleSystemModuleLink> GetAllByRoleId(Guid roleId)
        {
            var roleSystemModuleLinks = _context.RoleSystemModuleLinks.Where(r => r.RoleId == roleId);

            return roleSystemModuleLinks;
        }
    }
}
