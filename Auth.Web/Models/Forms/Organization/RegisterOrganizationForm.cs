using Auth.Web.Forms.Organization.Requisites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Web.Forms.Organization
{
    public class RegisterOrganizationForm
    {
        public string Title { get; set; }
        public string TitleShort { get; set; }
        public Guid? ParentOrganizationId { get; set; }
        public Guid OrganizationTypeId { get; set; }
        public string LegalAddress { get; set; }
        public string PostAddress { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Inn { get; set; }
        public string Kpp { get; set; }
        public string Ogrn { get; set; }
        public string Okved { get; set; }
        public string Okpo { get; set; }
        public string Okato { get; set; }
        public string AccountNumber { get; set; }
        public string BankTitle { get; set; }
        public string Bik { get; set; }
        public string BankCorrespAccount { get; set; }
    }
}
