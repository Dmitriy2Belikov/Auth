using Auth.DataLayer.Models;
using Auth.DataLayer.Repositories.PersonRepos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.Services.PrimitivesServices.PersonServices
{
    public class PersonService : IPersonRepository
    {
        private DataLayer.Repositories.PersonRepos.IPersonRepository _personRepository;

        public PersonService(DataLayer.Repositories.PersonRepos.IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public void Add(Person person)
        {
            _personRepository.Add(person);
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

        public void Update(Person updatedPerson)
        {
            _personRepository.Update(updatedPerson);
        }

        public void Remove(Guid id)
        {
            _personRepository.Remove(id);
        }
    }
}
