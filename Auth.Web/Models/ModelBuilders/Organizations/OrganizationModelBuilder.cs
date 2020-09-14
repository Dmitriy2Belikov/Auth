using Auth.DataLayer.Models.Organizations;
using Auth.Services.PrimitivesServices.OrganizationServices;
using Auth.Services.PrimitivesServices.OrganizationTypeServices;
using Auth.Web.Models.ModelBuilders.OrganizationTypes;
using Auth.Web.Models.ViewModels.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Web.Models.ModelBuilders.Organizations
{
    public class OrganizationModelBuilder : IOrganizationModelBuilder
    {
        private IOrganizationService _organizationService;
        private IOrganizationTypeService _organizationTypeService;

        private IOrganizationTypeModelBuilder _organizationTypeModelBuilder;

        public OrganizationModelBuilder(
            IOrganizationService organizationService, 
            IOrganizationTypeService organizationTypeService, 
            IOrganizationTypeModelBuilder organizationTypeModelBuilder)
        {
            _organizationService = organizationService;
            _organizationTypeService = organizationTypeService;
            _organizationTypeModelBuilder = organizationTypeModelBuilder;
        }

        public OrganizationViewModel BuildNew(Organization organization)
        {
            var organizationType = _organizationTypeService.Get(organization.OrganizationTypeId);
            var parentOrganization = _organizationService.Get(organization.ParentOrganizationId.Value);

            var organizationTypeViewModel = _organizationTypeModelBuilder.BuildNew(organizationType);
            var parentOrganizationViewModel = BuildNew(parentOrganization);

            var organizationViewModel = new OrganizationViewModel()
            {
                Id = organization.Id,
                Title = organization.Title,
                TitleShort = organization.TitleShort,
                ParentOrganization = parentOrganizationViewModel,
                OrganizationType = organizationTypeViewModel
            };

            return organizationViewModel;
        }
    }
}
