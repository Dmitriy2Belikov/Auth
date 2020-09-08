using Auth.DataLayer.Models;
using Auth.DataLayer.Repositories.ModelRepos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Auth.DataLayer.Repositories.UserRoleRepos
{
    public class UserRoleRepository : ModelRepository<UserRoleLink>, IUserRoleRepository
    {
        private UserDbContext _context;

        public UserRoleRepository(UserDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<UserRoleLink> GetAllByRoleId(Guid roleId)
        {
            var userRoleLinks = _context.UserRoleLinks.Where(u => u.RoleId == roleId);

            return userRoleLinks;
        }

        public IEnumerable<UserRoleLink> GetAllByUserId(Guid userId)
        {
            var userRoleLinks = _context.UserRoleLinks.Where(u => u.UserId == userId);

            return userRoleLinks;
        }
    }
}
