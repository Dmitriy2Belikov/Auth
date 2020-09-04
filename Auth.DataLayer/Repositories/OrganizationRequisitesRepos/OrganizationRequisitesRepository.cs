using Auth.DataLayer.Models;
using Auth.DataLayer.Repositories.ModelRepos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.Repositories.OrganizationRequisitesRepos
{
    public class OrganizationRequisitesRepository : ModelRepository<OrganizationRequisite>, IOrganizationRequisitesRepository
    {
        private UserDbContext _context;

        public OrganizationRequisitesRepository(UserDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
