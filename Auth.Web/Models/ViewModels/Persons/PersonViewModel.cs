using Auth.DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Web.Models.ViewModels.Persons
{
    public class PersonViewModel
    {
        public Guid Id { get; set; }
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
