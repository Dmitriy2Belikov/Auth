using Auth.DataLayer.Enums;
using System;
using System.Collections.Generic;

namespace Auth.Web.Forms.Account
{
    public class EditUserForm
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public List<Guid> RoleIds { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SurName { get; set; }
        public Genders Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Snils { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string RegistrationAddress { get; set; }
        public string FactAddress { get; set; }
        public string OtherPhones { get; set; }
    }
}
