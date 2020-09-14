using Auth.Web.Models.ViewModels.OrganizationTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Web.Models.ViewModels.Organizations
{
    public class OrganizationViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string TitleShort { get; set; }
        public OrganizationViewModel ParentOrganization { get; set; }
        public OrganizationTypeViewModel OrganizationType { get; set; }
    }
}
