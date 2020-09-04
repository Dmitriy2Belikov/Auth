using Auth.DataLayer.Models;
using Auth.Services.PrimitivesServices.OrganizationTypeServices;
using Auth.Web.Forms.OrganizationType;
using System;

namespace Auth.Web.Builders.OrganizationTypes
{
    public class OrganizationTypeBuilder : IOrganizationTypeBuilder
    {
        private IOrganizationTypeService _organizationTypeService;

        public OrganizationTypeBuilder(IOrganizationTypeService organizationTypeService)
        {
            _organizationTypeService = organizationTypeService;
        }

        public OrganizationType BuildNew(RegisterOrganizationTypeForm registerOrganizationTypeForm)
        {
            var organizationType = new OrganizationType()
            {
                Id = Guid.NewGuid(),
                Title = registerOrganizationTypeForm.Title
            };

            return organizationType;
        }

        public OrganizationType Edit(Guid id, EditOrganizationTypeForm editOrganizationTypeForm)
        {
            var organizationType = _organizationTypeService.Get(id);

            organizationType.Title = editOrganizationTypeForm.Title;

            return organizationType;
        }
    }
}
