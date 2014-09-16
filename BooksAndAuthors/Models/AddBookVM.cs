using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksAndAuthors.Models
{
    public class AddBookVM
    {
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public bool IsHardback { get; set; }
    }
}