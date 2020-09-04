using Auth.DataLayer.Models;
using Auth.DataLayer.Repositories.OrganizationRepos;
using Auth.DataLayer.Repositories.OrganizationRequisitesRepos;
using Auth.DataLayer.Repositories.OrganizationTypeRepos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.Services.PrimitivesServices.OrganizationServices
{
    public class OrganizationService : IOrganizationService
    {
        private IOrganizationRepository _organizationRepository;
        private IOrganizationRequisitesRepository _organizationRequisitesRepository;
        private IOrganizationTypeRepository _organizationTypeRepository;

        public OrganizationService(
            IOrganizationRepository organicationRepository, 
            IOrganizationRequisitesRepository organizationRequisitesRepository, 
            IOrganizationTypeRepository organizationTypeRepository)
        {
            _organizationRepository = organicationRepository;
            _organizationRequisitesRepository = organizationRequisitesRepository;
            _organizationTypeRepository = organizationTypeRepository;
        }

        public Organization Add(Organization organization, OrganizationRequisite organizationRequisite)
        {
            _organizationRepository.Add(organization);

            _organizationRequisitesRepository.Add(organizationRequisite);

            return organization;
        }

        public Organization Get(Guid id)
        {
            var organization = _organizationRepository.Get(id);

            return organization;
        }

        public IEnumerable<Organization> GetAll()
        {
            var organizations = _organizationRepository.GetAll();

            return organizations;
        }

        public Organization Update(Organization organization)
        {
            _organizationRepository.Update(organization);

            return organization;
        }

        public void Remove(Organization organization)
        {
            _organizationRepository.Remove(organization);
        }

        public void Remove(Guid id)
        {
            _organizationRepository.Remove(id);
        }

        public bool Contains(Guid id)
        {
            var isContains = _organizationRepository.Contains(id);

            return isContains;
        }

        public OrganizationRequisite GetRequisites(Guid id)
        {
            var organizationRequisite = _organizationRequisitesRepository.Get(id);

            return organizationRequisite;
        }
    }
}
