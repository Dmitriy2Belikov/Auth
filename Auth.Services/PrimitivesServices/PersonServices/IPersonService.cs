using Auth.DataLayer.Enums;
using Auth.DataLayer.Models;
using Auth.DataLayer.Models.Persons;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.Services.PrimitivesServices.PersonServices
{
    public interface IPersonService
    {
        Person Add(string firstName,
            string lastName,
            string surName,
            Genders gender,
            DateTime? birthDate,
            string snils,
            string email,
            string phone,
            string registrationAddress,
            string factAddress,
            string otherPhones);
        Person Get(Guid id);
        IEnumerable<Person> GetAll();
        Person Update(Guid userId,
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
            string otherPhones);
        void Remove(Guid id);
    }
}
