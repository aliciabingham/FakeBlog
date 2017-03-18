using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FakeBlog.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [Required] // Cannot be null
        [MinLength(3)]
        [MaxLength(60)]
        public string Title { get; set; }

        public Author author { get; set; }

        public DateTime DateCreated { get; set; } // Required by default

        public DateTime PublishedAt { get; set; }

        [Required]
        [MinLength(3)]
        public string Body { get; set; }

        public bool IsDraft { get; set; }

        public string URL { get; set; }

        public bool IsEdited { get; set; }
    }
}