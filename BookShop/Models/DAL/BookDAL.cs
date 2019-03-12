using BookShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Models.DAL
{
    public static class BookDAL
    {
        public static int InsertBook(Book book)
        {
            using (var db = new BookShopEntities())
            {
                db.Books.Add(book);
                var result = db.SaveChanges();
                return result;
            }
        }

        public static int UpdateBook(Book bookEntity)
        {
            using (var db = new BookShopEntities())
            {
                var book = db.Books.Find(bookEntity.ID);
                book.Name = bookEntity.Name;
                book.MetaTitle = bookEntity.MetaTitle;
                book.Image = bookEntity.Image;
                book.Price = bookEntity.Price;
                book.Description = bookEntity.Description;
                book.Quantity = bookEntity.Quantity;
                book.PublisherID = bookEntity.PublisherID;
                book.BookCategoryID = bookEntity.BookCategoryID;
                var result = db.SaveChanges();
                return result;
            }
        }

        public static int DeleteBook(int ID)
        {
            using (var db = new BookShopEntities())
            {
                var book = db.Books.Find(ID);
                db.Books.Remove(book);
                var result = db.SaveChanges();
                return result;
            }
        }

        public static List<Book> GetThreeBook()
        {
            using (var db = new BookShopEntities())
            {
                var books = db.Books.Take(3).ToList();
                return books;
            }
        }

        public static List<Book> GetNewBooks()
        {
            using (var db = new BookShopEntities())
            {
                var newBooks = db.Books
                    .Where(x => x.New == true)
                    .OrderBy(x => x.Price)
                    .ToList();
                return newBooks;
            }
        }

        public static List<Book> GetBooks()
        {
            using (var db = new BookShopEntities())
            {
                var books = db.Books.ToList();
                return books;
            }
        }

        public static Book GetBook(int ID)
        {
            using (var db = new BookShopEntities())
            {
                var book = db.Books.Find(ID);
                return book;
            }
        }

        public static List<Book> GetBooksCategoryInOrder(int bookCategoryID)
        {
            using (var db = new BookShopEntities())
            {
                var books = db.Books
                    .Where(x => x.BookCategoryID == bookCategoryID)
                    .OrderBy(x => x.Price)
                    .ToList();
                return books;
            }
        }

        public static List<Book> GetBooksPublisherInOrder(int publisherID )
        {
            using (var db = new BookShopEntities())
            {
                var books = db.Books
                    .Where(x => x.PublisherID == publisherID)
                    .OrderBy(x => x.Price)
                    .ToList();
                return books;
            }
        }

        public static List<Book> GetBooksBelongToBookCategory(int bookCategoryID)
        {
            using (var db = new BookShopEntities())
            {
                var books = db.Books
                    .Where(x => x.BookCategoryID == bookCategoryID)
                    .ToList();
                return books;
            }
        }

        public static List<Book> GetBooksBelongToBookPublisher(int bookPublisherID)
        {
            using (var db = new BookShopEntities())
            {
                var books = db.Books
                    .Where(x => x.PublisherID == bookPublisherID)
                    .ToList();
                return books;
            }
        }

        public static List<Book> SearchBooks(string keyword)
        {
            using (var db = new BookShopEntities())
            {
                var books = db.Books.Where(x => x.Name.Contains(keyword))
                    .OrderBy(x => x.Name)
                    .ToList();
                return books;
            }
        }

        public static List<Book> GetBooksInOrder()
        {
            using (var db = new BookShopEntities())
            {
                var books = db.Books.OrderBy(x => x.Name).ToList();
                return books;
            }
        }
    }
}