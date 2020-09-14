using Auth.DataLayer.Models.Organizations;
using Auth.Web.Models.ViewModels.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Web.Models.ModelBuilders.Organizations
{
    public interface IOrganizationModelBuilder
    {
        OrganizationViewModel BuildNew(Organization organization);
    }
}
