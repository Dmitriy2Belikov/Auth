using Auth.DataLayer.Models;
using Auth.DataLayer.Models.OrganizationRequisites;
using Auth.DataLayer.Models.Organizations;
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

        private IOrganizationFactory _organizationFactory;
        private IOrganizationRequisiteFactory _organizationRequisiteFactory;

        public OrganizationService(
            IOrganizationRepository organicationRepository,
            IOrganizationRequisitesRepository organizationRequisitesRepository,
            IOrganizationTypeRepository organizationTypeRepository,
            IOrganizationRepository organizationRepository,
            IOrganizationFactory organizationFactory, 
            IOrganizationRequisiteFactory organizationRequisiteFactory)
        {
            _organizationRepository = organicationRepository;
            _organizationRequisitesRepository = organizationRequisitesRepository;
            _organizationTypeRepository = organizationTypeRepository;
            _organizationRepository = organizationRepository;
            _organizationFactory = organizationFactory;
            _organizationRequisiteFactory = organizationRequisiteFactory;
        }

        public Organization Add(
                                string title,
                                string titleShort,
                                Guid? parentOrganizationId,
                                Guid organizationTypeId,
                                string legalAddress,
                                string postAddress,
                                string phone,
                                string fax,
                                string email,
                                string inn,
                                string kpp,
                                string ogrn,
                                string okved,
                                string okpo,
                                string okato,
                                string accountNumber,
                                string bankTitle,
                                string bik,
                                string bankCorrespAccount)
        {
            var organization = _organizationFactory.Create(
                title, 
                titleShort, 
                parentOrganizationId, 
                organizationTypeId);

            var organizationRequisites = _organizationRequisiteFactory.Create(
                organization.Id, 
                legalAddress, 
                postAddress, 
                phone, 
                fax, 
                email, 
                inn, 
                kpp, 
                ogrn, 
                okved, 
                okpo, 
                okato, 
                accountNumber, 
                bankTitle, 
                bik, 
                bankCorrespAccount);

            _organizationRepository.Add(organization);

            _organizationRequisitesRepository.Add(organizationRequisites);

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

        public Organization Update(Guid id,
                                string title,
                                string titleShort,
                                Guid? parentOrganizationId,
                                Guid organizationTypeId,
                                string legalAddress,
                                string postAddress,
                                string phone,
                                string fax,
                                string email,
                                string inn,
                                string kpp,
                                string ogrn,
                                string okved,
                                string okpo,
                                string okato,
                                string accountNumber,
                                string bankTitle,
                                string bik,
                                string bankCorrespAccount)
        {
            var organization = _organizationFactory.Edit(id,
                                                        title,
                                                       titleShort,
                                                       parentOrganizationId,
                                                       organizationTypeId);

            var organizationRequisites = _organizationRequisiteFactory.Edit(organization.Id,
                                                                              legalAddress,
                                                                              postAddress,
                                                                              phone,
                                                                              fax,
                                                                              email,
                                                                              inn,
                                                                              kpp,
                                                                              ogrn,
                                                                              okved,
                                                                              okpo,
                                                                              okato,
                                                                              accountNumber,
                                                                              bankTitle,
                                                                              bik,
                                                                              bankCorrespAccount);

            _organizationRepository.Update(organization);

            _organizationRequisitesRepository.Update(organizationRequisites);
                                                                              
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
