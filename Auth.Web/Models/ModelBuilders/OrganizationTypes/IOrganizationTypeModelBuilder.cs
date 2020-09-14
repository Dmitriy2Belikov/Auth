using Auth.DataLayer.Models.OrganizationTypes;
using Auth.Web.Models.ViewModels.OrganizationTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Web.Models.ModelBuilders.OrganizationTypes
{
    public interface IOrganizationTypeModelBuilder
    {
        OrganizationTypeViewModel BuildNew(OrganizationType organizationType);
    }
}
