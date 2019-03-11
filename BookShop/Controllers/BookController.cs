using BookShop.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShop.Controllers
{
    public class BookController : Controller
    {
        // GET: Book

        [HttpGet]
        public ActionResult BookDetail (int ID)
        {
            var book = BookDAL.GetBook(ID);
            ViewBag.BookCategory = BookCategoryDAL.GetBookCategory(book.BookCategoryID.Value);
            ViewBag.Publisher = PublisherDAL.GetBookPublisher(book.PublisherID.Value);
            if (book == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(book);
        }

        [HttpGet]
        public ActionResult BooksCategory(int ID)
        {
            var books = BookDAL.GetBooksCategoryInOrder(ID);
            ViewBag.BookCategories = BookCategoryDAL.GetBookCategories();
            if (books == null)
            {
                ViewBag.Books = "Không có sách nào thuộc chủ đề này";
            }
            return View(books);
        }

        [HttpGet]
        public ActionResult OthersBookCategory()
        {
            int bookCategoryID = BookCategoryDAL.GetBookCategory();
            ViewBag.BookCategories = BookDAL.GetBooksBelongToBookCategory(bookCategoryID);
            var bookCategories = BookCategoryDAL.GetBookCategories();
            return View(bookCategories);
        }

        [HttpGet]
        public ActionResult BooksPublisher(int ID)
        {
            var books = BookDAL.GetBooksPublisherInOrder(ID);
            ViewBag.BookPublishers = PublisherDAL.GetPublishers();
            if (books == null)
            {
                ViewBag.Books = "Không có sách nào thuộc nhà xuất bản này";
            }
            return View(books);
        }

        [HttpGet]
        public ActionResult OthersBookPublisher()
        {
            int bookPublisherID = PublisherDAL.GetBookPublisher();
            ViewBag.BookPublishers = BookDAL.GetBooksBelongToBookPublisher(bookPublisherID);
            var bookPublishers = PublisherDAL.GetPublishers();
            return View(bookPublishers);
        }
    }
}