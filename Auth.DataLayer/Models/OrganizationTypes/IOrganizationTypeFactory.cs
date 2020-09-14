using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.Models.OrganizationTypes
{
    public interface IOrganizationTypeFactory
    {
        OrganizationType Create(string title);
        OrganizationType Edit(Guid id, string title);
    }
}
