using Auth.DataLayer.Models.Persons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.DataLayer.Models.Users
{
    public class User
    {
        [Key]
        [ForeignKey("Person")]
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime? LastActionTime { get; set; }

        public Person Person { get; set; }
    }
}
