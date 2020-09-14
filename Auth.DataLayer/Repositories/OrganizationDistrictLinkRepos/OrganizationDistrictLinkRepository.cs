using Auth.DataLayer.Models;
using Auth.DataLayer.Models.OrganizationDistrictLinks;
using Auth.DataLayer.Repositories.ModelRepos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.Repositories.OrganizationDistrictLinkRepos
{
    public class OrganizationDistrictLinkRepository : ModelRepository<OrganizationDistrictLink>, IOrganizationDistrictLinkRepository
    {
        private UserDbContext _context;

        public OrganizationDistrictLinkRepository(UserDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
