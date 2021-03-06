﻿using Auth.DataLayer.Models;
using Auth.DataLayer.Models.Persons;
using Auth.DataLayer.Models.Roles;
using Auth.DataLayer.Models.Users;
using Auth.DataLayer.Repositories.ModelRepos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Auth.DataLayer.Repositories.UserRepos
{
    public class UserRepository : ModelRepository<User>, IUserRepository
    {
        private UserDbContext _context;

        public UserRepository(UserDbContext context) : base(context)
        {
            _context = context;
        }

        public User Get(string login)
        {
            var user = _context.Users.FirstOrDefault(u => u.Login == login);

            return user;
        }

        public IEnumerable<Role> GetUserRoles(Guid id)
        {
            var roles = _context.UserRoleLinks
                .Include(u => u.User)
                .Include(r => r.Role)
                .Where(u => u.User.Id == id)
                .Select(r => r.Role);

            return roles;
        }

        public IEnumerable<string> GetAllLogins()
        {
            var logins = _context.Users.Select(u => u.Login);

            return logins;
        }

        public Person GetPerson(Guid id)
        {
            var person = _context.Persons.FirstOrDefault(p => p.Id == id);

            return person;
        }
    }
}
