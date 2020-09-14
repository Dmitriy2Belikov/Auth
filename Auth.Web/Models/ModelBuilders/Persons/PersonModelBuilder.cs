using Auth.DataLayer.Models.Persons;
using Auth.Web.Models.ViewModels.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Web.Models.ModelBuilders.Persons
{
    public class PersonModelBuilder : IPersonModelBuilder
    {
        public PersonViewModel BuildNew(Person person)
        {
            var personViewModel = new PersonViewModel()
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                SurName = person.SurName,
                BirthDate = person.BirthDate,
                Gender = person.Gender,
                Phone = person.Phone,
                Email = person.Email,
                RegistrationAddress = person.RegistrationAddress,
                FactAddress = person.FactAddress,
                OtherPhones = person.OtherPhones,
                Snils = person.Snils
            };

            return personViewModel;
        }
    }
}
