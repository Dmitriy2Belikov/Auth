using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.DataLayer.Models
{
    public class Organization
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string TitleShort { get; set; }
        public Guid? ParentOrganizationId { get; set; }
        public Guid OrganizationTypeId { get; set; }

        [ForeignKey("OrganizationTypeId")]
        public OrganizationType OrganizationType { get; set; }
    }
}
