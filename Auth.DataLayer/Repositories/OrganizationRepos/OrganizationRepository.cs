using Auth.DataLayer.Models;
using Auth.DataLayer.Repositories.ModelRepos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.Repositories.OrganizationRepos
{
    public class OrganizationRepository : ModelRepository<Organization>, IOrganizationRepository
    {
        private UserDbContext _context;

        public OrganizationRepository(UserDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
