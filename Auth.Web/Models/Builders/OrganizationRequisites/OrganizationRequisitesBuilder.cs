using Auth.DataLayer.Models;
using Auth.Services.PrimitivesServices.OrganizationServices;
using Auth.Web.Forms.Organization.Requisites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Web.Builders.OrganizationRequisites
{
    public class OrganizationRequisitesBuilder : IOrganizationRequisitesBuilder
    {
        private IOrganizationService _organizationService;

        public OrganizationRequisitesBuilder(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        public OrganizationRequisite BuildNew(Guid organizationId, RegisterRequisitesForm registerRequisitesForm)
        {
            var organizationRequisite = new OrganizationRequisite()
            {
                OrganizationId = organizationId,
                LegalAddress = registerRequisitesForm.LegalAddress,
                PostAddress = registerRequisitesForm.PostAddress,
                Phone = registerRequisitesForm.Phone,
                Fax = registerRequisitesForm.Fax,
                Email = registerRequisitesForm.Email,
                Inn = registerRequisitesForm.Inn,
                Kpp = registerRequisitesForm.Kpp,
                Ogrn = registerRequisitesForm.Ogrn,
                Okved = registerRequisitesForm.Okved,
                Okpo = registerRequisitesForm.Okpo,
                Okato = registerRequisitesForm.Okato,
                AccountNumber = registerRequisitesForm.AccountNumber,
                BankTitle = registerRequisitesForm.BankTitle,
                Bik = registerRequisitesForm.Bik,
                BankCorrespAccount = registerRequisitesForm.BankCorrespAccount
            };

            return organizationRequisite;
        }

        public OrganizationRequisite Edit(Guid organizationId, EditRequisitesForm editRequisitesForm)
        {
            var organizationRequisite = _organizationService.GetRequisites(organizationId);

            organizationRequisite.LegalAddress = editRequisitesForm.LegalAddress;
            organizationRequisite.PostAddress = editRequisitesForm.PostAddress;
            organizationRequisite.Phone = editRequisitesForm.Phone;
            organizationRequisite.Fax = editRequisitesForm.Fax;
            organizationRequisite.Email = editRequisitesForm.Email;
            organizationRequisite.Inn = editRequisitesForm.Inn;
            organizationRequisite.Kpp = editRequisitesForm.Kpp;
            organizationRequisite.Ogrn = editRequisitesForm.Ogrn;
            organizationRequisite.Okved = editRequisitesForm.Okved;
            organizationRequisite.Okpo = editRequisitesForm.Okpo;
            organizationRequisite.Okato = editRequisitesForm.Okato;
            organizationRequisite.AccountNumber = editRequisitesForm.AccountNumber;
            organizationRequisite.BankTitle = editRequisitesForm.BankTitle;
            organizationRequisite.Bik = editRequisitesForm.Bik;
            organizationRequisite.BankCorrespAccount = editRequisitesForm.BankCorrespAccount;

            return organizationRequisite;
        }
    }
}
