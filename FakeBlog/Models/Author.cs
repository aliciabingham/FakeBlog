using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FakeBlog.Models
{
    public class Author
    {
        [Key]
        public string Id { get; set; }

        public string Fullname { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public ICollection<Post> Posts { get; set; } // 1 to many 
    }
}