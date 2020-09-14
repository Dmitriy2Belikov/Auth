using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.Models.Organizations
{
    public interface IOrganizationFactory
    {
        Organization Create(string title, string titleShort, Guid? parentOrganizationId, Guid organizationTypeId);
        Organization Edit(Guid id, string title, string titleShort, Guid? parentOrganizationId, Guid organizationTypeId);
    }
}
