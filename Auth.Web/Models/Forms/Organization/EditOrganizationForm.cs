using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Web.Forms.Organization
{
    public class EditOrganizationForm
    {
        public string Title { get; set; }
        public string TitleShort { get; set; }
        public Guid? ParentOrganizationId { get; set; }
        public Guid OrganizationTypeId { get; set; }
    }
}
