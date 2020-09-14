using Auth.DataLayer.Enums;
using Auth.DataLayer.Repositories.PersonRepos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.Models.Persons
{
    public class PersonFactory : IPersonFactory
    {
        private IPersonRepository _personRepository;

        public PersonFactory(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public Person Create(string firstName,
                             string lastName,
                             string surName,
                             Genders gender,
                             DateTime? birthDate,
                             string snils,
                             string email,
                             string phone,
                             string registrationAddress,
                             string factAddress,
                             string otherPhones)
        {
            var person = new Person()
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                SurName = surName,
                Gender = gender,
                BirthDate = birthDate,
                Snils = snils,
                Email = email,
                Phone = phone,
                RegistrationAddress = registrationAddress,
                FactAddress = factAddress,
                OtherPhones = otherPhones
            };

            return person;
        }

        public Person Edit(Guid id, 
                            string firstName,
                             string lastName,
                             string surName,
                             Genders gender,
                             DateTime? birthDate,
                             string snils,
                             string email,
                             string phone,
                             string registrationAddress,
                             string factAddress,
                             string otherPhones)
        {
            var person = _personRepository.Get(id);

            person.FirstName = firstName;
            person.LastName = lastName;
            person.SurName = surName;
            person.Gender = gender;
            person.BirthDate = birthDate;
            person.Snils = snils;
            person.Email = email;
            person.Phone = phone;
            person.RegistrationAddress = registrationAddress;
            person.FactAddress = factAddress;
            person.OtherPhones = otherPhones;

            return person;
        }
    }
}
