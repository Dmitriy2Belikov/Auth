using Auth.DataLayer.Models;
using Auth.Web.Forms.Organization;
using System;

namespace Auth.Web.Builders.Organizations
{
    public interface IOrganizationBuilder
    {
        Organization BuildNew(RegisterOrganizationForm registerOrganizationForm);
        Organization Edit(Guid id, EditOrganizationForm editOrganizationForm);
    }
}
