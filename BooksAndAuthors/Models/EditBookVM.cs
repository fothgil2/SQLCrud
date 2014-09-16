using BooksAndAuthors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksAndAuthors.Models
{
    public class EditBookVM
    {
        public Book Book { get; set; }
        public int SelectedAuthor { get; set; }
        public List<AuthorVM> Authors { get; set; }
    }
}