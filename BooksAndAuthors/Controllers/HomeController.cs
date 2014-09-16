using BooksAndAuthors.DataModel;
using BooksAndAuthors.Model;
using BooksAndAuthors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooksAndAuthors.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            List<Author> model = db.Authors.Include("Books").ToList();

            return View(model);
        }
        public ActionResult AuthorDetail(int id)
        {
            AuthorDetailVM model = new AuthorDetailVM();

            using(ApplicationDbContext db = new ApplicationDbContext()) {
                model = db.Authors.Include("Books").Where(a => a.AuthorId == id).Select(x => new AuthorDetailVM()
                {
                    AuthorId = x.AuthorId,
                    Name = x.Name,
                    Books = x.Books
                }).FirstOrDefault();
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult AddBook(AddBookVM model)
        {

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Books.Add(new Book() { AuthorId = model.AuthorId, Title = model.Title, IsHardback = model.IsHardback });
                db.SaveChanges();
            }
            return RedirectToAction("AuthorDetail", new { id = model.AuthorId });
        }
        public ActionResult AddBook(int id)
        {
            AddBookVM model = new AddBookVM();
            model.AuthorId = id;
            return View(model);
        }
        [HttpPost]
        public ActionResult EditBook(EditBookVM model)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Book tempBook = db.Books.Where(x => x.BookId == model.Book.BookId).FirstOrDefault();
                tempBook.AuthorId = model.SelectedAuthor;
                tempBook.Title = model.Book.Title;
                tempBook.IsHardback = model.Book.IsHardback;
                db.SaveChanges();
            }
            return RedirectToAction("AuthorDetail", new { id = model.SelectedAuthor });
        }
        public ActionResult EditBook(int id)
        {
            EditBookVM model = new EditBookVM();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model.Book = db.Books.Where(x => x.BookId == id).FirstOrDefault();
                model.SelectedAuthor = model.Book.AuthorId;
                model.Authors = db.Authors.Select(x => new AuthorVM() { AuthorId = x.AuthorId, Name = x.Name }).OrderByDescending(x => x.Name).ToList();
            }
            return View(model);
        }
        public ActionResult DeleteBook(int id)
        {
            Book model = new Book();
            using (ApplicationDbContext db = new ApplicationDbContext()) 
            {
                model = db.Books.Include("Author").Where(x => x.BookId == id).FirstOrDefault();
            }

            return View(model);
        }
        public ActionResult ConfirmDeleteBook(int id, int authorId)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Book tempBook = db.Books.Where(x => x.BookId == id).FirstOrDefault();
                db.Books.Remove(tempBook);
                db.SaveChanges();
            }
            return RedirectToAction("AuthorDetail", new { id = authorId });
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}