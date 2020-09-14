using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.Models.OrganizationDistrictLinks
{
    public interface IOrganizationDistrictLinkFactory
    {
        OrganizationDistrictLink Create(Guid organizationId, Guid districtId);
    }
}
