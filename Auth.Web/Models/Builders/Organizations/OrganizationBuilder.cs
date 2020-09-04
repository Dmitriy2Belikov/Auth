using Auth.DataLayer.Models;
using Auth.Services.PrimitivesServices.OrganizationServices;
using Auth.Web.Forms.Organization;
using System;

namespace Auth.Web.Builders.Organizations
{
    public class OrganizationBuilder : IOrganizationBuilder
    {
        private IOrganizationService _organizationService;

        public OrganizationBuilder(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        public Organization BuildNew(RegisterOrganizationForm registerOrganizationForm)
        {
            var organization = new Organization()
            {
                Id = Guid.NewGuid(),
                Title = registerOrganizationForm.Title,
                TitleShort = registerOrganizationForm.TitleShort,
                ParentOrganizationId = registerOrganizationForm.ParentOrganizationId,
                OrganizationTypeId = registerOrganizationForm.OrganizationTypeId
            };

            return organization;
        }

        public Organization Edit(Guid id, EditOrganizationForm editOrganizationForm)
        {
            var organization = _organizationService.Get(id);

            organization.Title = editOrganizationForm.Title;
            organization.TitleShort = editOrganizationForm.TitleShort;
            organization.ParentOrganizationId = editOrganizationForm.ParentOrganizationId;
            organization.OrganizationTypeId = editOrganizationForm.OrganizationTypeId;

            return organization;
        }
    }
}
