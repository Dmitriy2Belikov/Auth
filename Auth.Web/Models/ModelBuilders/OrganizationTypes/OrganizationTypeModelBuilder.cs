using Auth.DataLayer.Models.OrganizationTypes;
using Auth.Web.Models.ViewModels.OrganizationTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Web.Models.ModelBuilders.OrganizationTypes
{
    public class OrganizationTypeModelBuilder : IOrganizationTypeModelBuilder
    {
        public OrganizationTypeViewModel BuildNew(OrganizationType organizationType)
        {
            var organizationTypeViewModel = new OrganizationTypeViewModel()
            {
                Id = organizationType.Id,
                Title = organizationType.Title
            };

            return organizationTypeViewModel;
        }
    }
}
