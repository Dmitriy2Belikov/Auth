using Auth.DataLayer.Models.Persons;
using Auth.Web.Models.ViewModels.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Web.Models.ModelBuilders.Persons
{
    public interface IPersonModelBuilder
    {
        PersonViewModel BuildNew(Person person);
    }
}
