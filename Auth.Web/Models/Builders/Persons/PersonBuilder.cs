using Auth.DataLayer.Models;
using Auth.Services.PrimitivesServices.PersonServices;
using Auth.Web.Forms.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Web.Models.Builders.Persons
{
    public class PersonBuilder : IPersonBuilder
    {
        private IPersonRepository _personService;

        public PersonBuilder(IPersonRepository personService)
        {
            _personService = personService;
        }

        public Person BuildNew(RegisterUserForm registerUserForm)
        {
            var person = new Person()
            {
                Id = Guid.NewGuid(),
                FirstName = registerUserForm.FirstName,
                LastName = registerUserForm.LastName,
                SurName = registerUserForm.SurName,
                Gender = registerUserForm.Gender,
                BirthDate = registerUserForm.BirthDate,
                Snils = registerUserForm.Snils,
                Email = registerUserForm.Email,
                Phone = registerUserForm.Phone,
                RegistrationAddress = registerUserForm.RegistrationAddress,
                FactAddress = registerUserForm.FactAddress,
                OtherPhones = registerUserForm.OtherPhones
            };

            return person;
        }
    }
}
