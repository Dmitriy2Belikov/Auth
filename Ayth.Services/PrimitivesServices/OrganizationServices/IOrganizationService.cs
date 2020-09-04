using Auth.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.Services.PrimitivesServices.OrganizationServices
{
    public interface IOrganizationService
    {
        Organization Add(Organization organization, OrganizationRequisite organizationRequisite);
        Organization Get(Guid id);
        IEnumerable<Organization> GetAll();
        Organization Update(Organization organization);
        void Remove(Organization organization);
        void Remove(Guid id);
        bool Contains(Guid id);
        OrganizationRequisite GetRequisites(Guid id);
    }
}
