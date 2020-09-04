using Auth.DataLayer.Models;
using Auth.Web.Forms.Organization.Requisites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Web.Builders.OrganizationRequisites
{
    public interface IOrganizationRequisitesBuilder
    {
        OrganizationRequisite BuildNew(Guid organizationId, RegisterRequisitesForm registerRequisitesForm);
        OrganizationRequisite Edit(Guid organizationId, EditRequisitesForm editRequisitesForm);
    }
}
