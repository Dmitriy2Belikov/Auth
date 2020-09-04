using Auth.DataLayer.Models;
using Auth.DataLayer.Repositories.ModelRepos;

namespace Auth.DataLayer.Repositories.RoleRepos
{
    public interface IRoleRepository : IModelRepository<Role>
    {
        Role Get(string name);
    }
}
