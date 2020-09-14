using Auth.DataLayer.Models;
using Auth.DataLayer.Models.OrganizationRequisites;
using Auth.DataLayer.Models.Organizations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.Services.PrimitivesServices.OrganizationServices
{
    public interface IOrganizationService
    {
        Organization Add(string title,
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
                         string bankCorrespAccount);
        Organization Get(Guid id);
        IEnumerable<Organization> GetAll();
        Organization Update(Guid id,
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
                                string bankCorrespAccount);
        void Remove(Organization organization);
        void Remove(Guid id);
        bool Contains(Guid id);
        OrganizationRequisite GetRequisites(Guid id);
    }
}
