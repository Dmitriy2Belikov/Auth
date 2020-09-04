using Auth.DataLayer.Models;
using Auth.DataLayer.Repositories.OrganizationTypeRepos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.Services.PrimitivesServices.OrganizationTypeServices
{
    public class OrganizationTypeService : IOrganizationTypeService
    {
        private IOrganizationTypeRepository _organizationTypeRepository;

        public OrganizationTypeService(IOrganizationTypeRepository organizationTypeRepository)
        {
            _organizationTypeRepository = organizationTypeRepository;
        }

        public OrganizationType Add(OrganizationType organizationType)
        {
            _organizationTypeRepository.Add(organizationType);

            return organizationType;
        }

        public OrganizationType Get(Guid id)
        {
            var organizationType = _organizationTypeRepository.Get(id);

            return organizationType;
        }

        public IEnumerable<OrganizationType> GetAll()
        {
            var organizationTypes = _organizationTypeRepository.GetAll();

            return organizationTypes;
        }

        public OrganizationType Update(OrganizationType organizationType)
        {
            _organizationTypeRepository.Update(organizationType);

            return organizationType;
        }

        public void Remove(Guid id)
        {
            _organizationTypeRepository.Remove(id);
        }

        public bool Contains(Guid id)
        {
            var isContained = _organizationTypeRepository.Contains(id);

            return isContained;
        }
    }
}
