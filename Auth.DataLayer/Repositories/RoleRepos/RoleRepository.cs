using Auth.DataLayer.Models;
using Auth.DataLayer.Repositories.ModelRepos;
using System.Linq;

namespace Auth.DataLayer.Repositories.RoleRepos
{
    public class RoleRepository : ModelRepository<Role>, IRoleRepository
    {
        private UserDbContext _context;

        public RoleRepository(UserDbContext context) : base(context)
        {
            _context = context;
        }

        public Role Get(string name)
        {
            var role = _context.Roles.FirstOrDefault(r => r.Name == name);

            return role;
        }
    }
}
