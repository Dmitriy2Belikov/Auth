using Auth.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.Services.PrimitivesServices.PersonServices
{
    public interface IPersonRepository
    {
        void Add(Person person);
        Person Get(Guid id);
        IEnumerable<Person> GetAll();
        void Update(Person updatedPerson);
        void Remove(Guid id);
    }
}
