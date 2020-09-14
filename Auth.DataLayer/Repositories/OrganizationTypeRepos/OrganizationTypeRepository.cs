using Auth.DataLayer.Models;
using Auth.DataLayer.Models.OrganizationTypes;
using Auth.DataLayer.Repositories.ModelRepos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.Repositories.OrganizationTypeRepos
{
    public class OrganizationTypeRepository : ModelRepository<OrganizationType>, IOrganizationTypeRepository
    {
        private UserDbContext _context;

        public OrganizationTypeRepository(UserDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
