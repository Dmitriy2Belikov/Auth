using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.DataLayer.Models.Roles
{
    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}
