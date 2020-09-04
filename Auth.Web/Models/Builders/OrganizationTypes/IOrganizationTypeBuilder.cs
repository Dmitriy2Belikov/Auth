using Auth.DataLayer.Models;
using Auth.Web.Forms.OrganizationType;
using System;

namespace Auth.Web.Builders.OrganizationTypes
{
    public interface IOrganizationTypeBuilder
    {
        OrganizationType BuildNew(RegisterOrganizationTypeForm registerOrganizationTypeForm);
        OrganizationType Edit(Guid id, EditOrganizationTypeForm editOrganizationTypeForm);
    }
}
