using BooksAndAuthors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksAndAuthors.Models
{
    public class AuthorDetailVM
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}