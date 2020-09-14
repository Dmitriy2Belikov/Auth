using Auth.DataLayer.Models.Organizations;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auth.DataLayer.Models.OrganizationDistrictLinks
{
    public class OrganizationDistrictLink
    {
        [Key, Column(Order = 1)]
        public Guid OrganizationId { get; set; }

        [Key, Column(Order = 2)]
        public Guid DistrictId { get; set; }


        [ForeignKey("OrganizationId")]
        public Organization Organization { get; set; }
    }
}
