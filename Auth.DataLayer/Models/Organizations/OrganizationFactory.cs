using Auth.DataLayer.Repositories.OrganizationRepos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.Models.Organizations
{
    public class OrganizationFactory : IOrganizationFactory
    {
        private IOrganizationRepository _organizationRepository;

        public OrganizationFactory(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public Organization Create(string title, string titleShort, Guid? parentOrganizationId, Guid organizationTypeId)
        {
            var organization = new Organization()
            {
                Id = Guid.NewGuid(),
                Title = title,
                TitleShort = titleShort,
                ParentOrganizationId = parentOrganizationId,
                OrganizationTypeId = organizationTypeId
            };

            return organization;
        }

        public Organization Edit(Guid id, string title, string titleShort, Guid? parentOrganizationId, Guid organizationTypeId)
        {
            var organization = _organizationRepository.Get(id);

            organization.Title = title;
            organization.TitleShort = titleShort;
            organization.ParentOrganizationId = parentOrganizationId;
            organization.OrganizationTypeId = organizationTypeId;

            return organization;
        }
    }
}
