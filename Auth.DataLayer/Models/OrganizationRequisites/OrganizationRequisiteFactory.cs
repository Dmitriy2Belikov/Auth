using Auth.DataLayer.Repositories.OrganizationRequisitesRepos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.Models.OrganizationRequisites
{
    class OrganizationRequisiteFactory : IOrganizationRequisiteFactory
    {
        public IOrganizationRequisitesRepository _organizationRequisitesRepository;

        public OrganizationRequisiteFactory(IOrganizationRequisitesRepository organizationRequisitesRepository)
        {
            _organizationRequisitesRepository = organizationRequisitesRepository;
        }

        public OrganizationRequisite Create(Guid organizationId,
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
            var organizationRequisite = new OrganizationRequisite()
            {
                OrganizationId = organizationId,
                LegalAddress = legalAddress,
                PostAddress = postAddress,
                Phone = phone,
                Fax = fax,
                Email = email,
                Inn = inn,
                Kpp = kpp,
                Ogrn = ogrn,
                Okved = okved,
                Okpo = okpo,
                Okato = okato,
                AccountNumber = accountNumber,
                BankTitle = bankTitle,
                Bik = bik,
                BankCorrespAccount = bankCorrespAccount
            };

            return organizationRequisite;
        }

        public OrganizationRequisite Edit(
                                          Guid organizationId,
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
            var organizationRequisite = _organizationRequisitesRepository.Get(organizationId);

            organizationRequisite.OrganizationId = organizationId;
            organizationRequisite.PostAddress = legalAddress;
            organizationRequisite.LegalAddress = postAddress;
            organizationRequisite.Phone = phone;
            organizationRequisite.Fax = fax;
            organizationRequisite.Email = email;
            organizationRequisite.Inn = inn;
            organizationRequisite.Kpp = kpp;
            organizationRequisite.Ogrn = ogrn;
            organizationRequisite.Okved = okved;
            organizationRequisite.Okpo = okpo;
            organizationRequisite.Okato = okato;
            organizationRequisite.AccountNumber = accountNumber;
            organizationRequisite.BankTitle = bankTitle;
            organizationRequisite.Bik = bik;
            organizationRequisite.BankCorrespAccount = bankCorrespAccount;

            return organizationRequisite;
        }
    }
}
