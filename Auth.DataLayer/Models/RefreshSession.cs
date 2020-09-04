using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Auth.DataLayer.Models
{
    public class RefreshSession
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string RefreshToken { get; set; }
        public string UserAgent { get; set; }

        [MaxLength(15)]
        public string IP { get; set; }

        public DateTime ExpiresIn { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
