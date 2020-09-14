using Auth.DataLayer.Repositories.RoleRepos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.Models.Roles
{
    public class RoleFactory : IRoleFactory
    {
        private IRoleRepository _roleReposiotry;

        public RoleFactory(IRoleRepository roleReposiotry)
        {
            _roleReposiotry = roleReposiotry;
        }

        public Role Create(string name)
        {
            var role = new Role()
            {
                Id = Guid.NewGuid(),
                Name = name
            };

            return role;
        }

        public Role Edit(Guid id, string name)
        {
            var role = _roleReposiotry.Get(id);

            role.Name = name;

            return role;
        }
    }
}
