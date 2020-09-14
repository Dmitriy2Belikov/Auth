using Auth.DataLayer.Enums;
using Auth.DataLayer.Models.Users;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auth.DataLayer.Models.Persons
{
    public class Person
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

        public User User { get; set; }
    }
}
