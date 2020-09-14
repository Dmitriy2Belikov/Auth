using Auth.DataLayer.Enums;
using Auth.DataLayer.Models.Persons;
using Auth.DataLayer.Repositories.PersonRepos;
using Auth.DataLayer.Repositories.UserRepos;
using System;
using System.Collections.Generic;

namespace Auth.Services.PrimitivesServices.PersonServices
{
    public class PersonService : IPersonService
    {
        private IPersonRepository _personRepository;
        private IPersonFactory _personFactory;
        private IUserRepository _userRepository;

        public PersonService(IPersonRepository personRepository, IPersonFactory personFactory, IUserRepository userRepository)
        {
            _personRepository = personRepository;
            _personFactory = personFactory;
            _userRepository = userRepository;
        }

        public Person Add(string firstName, 
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
            var person = _personFactory.Create(firstName, 
                lastName, 
                surName, 
                gender, 
                birthDate, 
                snils, 
                email, 
                phone, 
                registrationAddress, 
                factAddress, 
                otherPhones);

            _personRepository.Add(person);

            return person;
        }

        public Person Get(Guid id)
        {
            var person = _personRepository.Get(id);

            return person;
        }

        public IEnumerable<Person> GetAll()
        {
            var persons = _personRepository.GetAll();

            return persons;
        }

        public Person Update(Guid userId, 
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
            var person = _userRepository.GetPerson(userId);

            var updatedPerson = _personFactory.Edit(person.Id, firstName, lastName, surName, gender, birthDate, snils, email, phone, registrationAddress, factAddress, otherPhones);

            _personRepository.Update(updatedPerson);

            return updatedPerson;
        }

        public void Remove(Guid id)
        {
            _personRepository.Remove(id);
        }
    }
}
