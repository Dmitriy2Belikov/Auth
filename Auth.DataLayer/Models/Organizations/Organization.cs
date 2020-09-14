using Auth.DataLayer.Models.OrganizationTypes;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auth.DataLayer.Models.Organizations
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
