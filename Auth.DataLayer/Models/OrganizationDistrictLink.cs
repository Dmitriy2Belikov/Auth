using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Auth.DataLayer.Models
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
