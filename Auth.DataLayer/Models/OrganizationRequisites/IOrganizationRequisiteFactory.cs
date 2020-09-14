using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.Models.OrganizationRequisites
{
    public interface IOrganizationRequisiteFactory
    {
        OrganizationRequisite Create(
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
            string bankCorrespAccount);

        OrganizationRequisite Edit(
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
                                   string bankCorrespAccount);
    }
}
