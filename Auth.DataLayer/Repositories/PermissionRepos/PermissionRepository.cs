using Auth.DataLayer.Models;
using Auth.DataLayer.Repositories.ModelRepos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Auth.DataLayer.Repositories.PermissionRepos
{
    public class PermissionRepository : ModelRepository<Permission>, IPermissionRepository
    {
        private UserDbContext _context;

        public PermissionRepository(UserDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Permission> GetAllPermissionsByRoleId(Guid roleId)
        {
            var permissions = _context.Permissions
                .Where(p => p.RoleId == roleId)
                .Include(r => r.Rule)
                .Include(o => o.WorkingEntityOperation);

            return permissions;
        }
    }
}
