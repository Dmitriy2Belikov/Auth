using Auth.DataLayer.Repositories.OrganizationTypeRepos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.Models.OrganizationTypes
{
    public class OrganizationTypeFactory : IOrganizationTypeFactory
    {
        private IOrganizationTypeRepository _organizationTypeRepository;

        public OrganizationTypeFactory(IOrganizationTypeRepository organizationTypeRepository)
        {
            _organizationTypeRepository = organizationTypeRepository;
        }

        public OrganizationType Create(string title)
        {
            var organizationType = new OrganizationType()
            {
                Id = Guid.NewGuid(),
                Title = title
            };

            return organizationType;
        }

        public OrganizationType Edit(Guid id, string title)
        {
            var organizationType = _organizationTypeRepository.Get(id);

            organizationType.Title = title;

            return organizationType;
        }
    }
}
