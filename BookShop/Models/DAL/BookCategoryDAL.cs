using BookShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Models.DAL
{
    public static class BookCategoryDAL
    {
        public static List<BookCategory> GetFiveBookCategory()
        {
            using (var db = new BookShopEntities())
            {
                var bookCategories = db.BookCategories.Take(5).ToList();
                return bookCategories;
            }
        }

        public static List<BookCategory> GetBookCategories()
        {
            using (var db = new BookShopEntities())
            {
                var bookCategories = db.BookCategories.OrderBy(x => x.DisplayOrder).ToList();
                return bookCategories;
            }
        }

        public static int GetBookCategory()
        {
            using (var db = new BookShopEntities())
            {
                var book = db.BookCategories.ToList().ElementAt(0).ID;
                return book;
            }
        }

        public static string GetBookCategory(int ID)
        {
            using (var db = new BookShopEntities())
            {
                var nameBookCategory = db.BookCategories.Find(ID).Name;
                return nameBookCategory;
            }
        }
    }
}