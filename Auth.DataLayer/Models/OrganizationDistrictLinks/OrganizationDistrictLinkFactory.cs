using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.Models.OrganizationDistrictLinks
{
    public class OrganizationDistrictLinkFactory : IOrganizationDistrictLinkFactory
    {
        public OrganizationDistrictLink Create(Guid organizationId, Guid districtId)
        {
            var organizationDistrictLink = new OrganizationDistrictLink()
            {
                OrganizationId = organizationId,
                DistrictId = districtId
            };

            return organizationDistrictLink;
        }
    }
}
