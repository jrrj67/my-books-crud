using my_books.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;

namespace my_books.ViewModels
{
    public class BookVM
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsRead { get; set; }

        public DateTime? DateRead { get; set; }

        public int? Rate { get; set; }

        public string Genre { get; set; }

        public string CoverUrl { get; set; }

        public int PublisherId { get; set; }
    
        public List<int> AuthorIds { get; set; }
    }
}
