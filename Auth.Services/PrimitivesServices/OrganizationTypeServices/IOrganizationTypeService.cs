using Auth.DataLayer.Models;
using Auth.DataLayer.Models.OrganizationTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.Services.PrimitivesServices.OrganizationTypeServices
{
    public interface IOrganizationTypeService
    {
        OrganizationType Add(string title);
        OrganizationType Get(Guid id);
        IEnumerable<OrganizationType> GetAll();
        OrganizationType Update(Guid id, string title);
        void Remove(Guid id);
        bool Contains(Guid id);
    }
}
