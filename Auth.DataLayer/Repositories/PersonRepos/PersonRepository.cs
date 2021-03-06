﻿using Auth.DataLayer.Models;
using Auth.DataLayer.Models.Persons;
using Auth.DataLayer.Repositories.ModelRepos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.Repositories.PersonRepos
{
    public class PersonRepository : ModelRepository<Person>, IPersonRepository
    {
        private UserDbContext _context;

        public PersonRepository(UserDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
