using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using BooksAndAuthors.Model;

namespace BooksAndAuthors.DataModel.Migrations
{
    public class Seeder
    {
        public static void Seed(ApplicationDbContext context, bool createAuthor = false, bool createBook = false)
        {
            if (createAuthor) CreateAuthor(context); 
            if (createBook) CreateBook(context); 
        }

        private static void CreateAuthor(ApplicationDbContext context)
        {
            context.Authors.AddOrUpdate(a => a.Name,
                new Author() { Name = "J.K. Rowling", Age = 50, IsAlive = true },
                new Author() { Name = "George R. R. Martin", Age = 60, IsAlive = true},
                new Author() { Name = "Edgar Allen Poe", Age = 40, IsAlive = false}
                );
        }

        private static void CreateBook(ApplicationDbContext context)
        {
            context.Books.AddOrUpdate(b => b.Title,
                new Book() { Title = "Harry Potter 1", IsHardback = true, AuthorId = 1 },
                new Book() { Title = "Harry Potter 2", IsHardback = true, AuthorId = 1 },
                new Book() { Title = "Harry Potter 3", IsHardback = true, AuthorId = 1 },
                new Book() { Title = "Game of Thrones", IsHardback = true, AuthorId = 2 },
                new Book() { Title = "Game of Thrones: More of your favorite characters die", IsHardback = false, AuthorId = 2 },
                new Book() { Title = "The Raven", IsHardback = true, AuthorId = 3 },
                new Book() { Title = "The Beating Heart", IsHardback = false, AuthorId = 3 }
                );
        }
    }
}
