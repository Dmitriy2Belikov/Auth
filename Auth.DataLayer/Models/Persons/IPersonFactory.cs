using Auth.DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.Models.Persons
{
    public interface IPersonFactory
    {
        Person Create(string firstName,
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

        Person Edit(Guid id,
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
    }
}
