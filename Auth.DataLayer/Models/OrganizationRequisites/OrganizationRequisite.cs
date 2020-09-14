using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Auth.DataLayer.Models.OrganizationRequisites
{
    public class OrganizationRequisite
    {
        [Key]
        public Guid     OrganizationId { get; set; }

        public string LegalAddress { get; set; }
        public string PostAddress { get; set; }

        [MaxLength(255)]
        public string Phone { get; set; }

        [MaxLength(255)]
        public string Fax { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }

        [MaxLength(10)]
        public string Inn { get; set; }

        [MaxLength(9)]
        public string Kpp { get; set; }

        [MaxLength(13)]
        public string Ogrn { get; set; }

        [MaxLength(255)]
        public string Okved { get; set; }

        [MaxLength(8)]
        public string Okpo { get; set; }
        [MaxLength(11)]
        public string Okato { get; set; }

        [MaxLength(20)]
        public string AccountNumber { get; set; }

        [MaxLength(255)]
        public string BankTitle { get; set; }

        [MaxLength(9)]
        public string Bik { get; set; }

        [MaxLength(20)]
        public string BankCorrespAccount { get; set; }
    }
}
