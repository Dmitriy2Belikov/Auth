using Auth.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.Services.PrimitivesServices.OrganizationTypeServices
{
    public interface IOrganizationTypeService
    {
        OrganizationType Add(OrganizationType organizationType);
        OrganizationType Get(Guid id);
        IEnumerable<OrganizationType> GetAll();
        OrganizationType Update(OrganizationType organizationType);
        void Remove(Guid id);
        bool Contains(Guid id);
    }
}
