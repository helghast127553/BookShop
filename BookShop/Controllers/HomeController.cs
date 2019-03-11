using BookShop.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace BookShop.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index(int? page)
        {
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            var newBooks = BookDAL.GetNewBooks().ToPagedList(pageNumber, pageSize);
            return View(newBooks);
        }

        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            var mainMenu = MenuDAL.GetMenuByID(1);
            return PartialView(mainMenu);
        }

        [ChildActionOnly]
        public ActionResult MenuLeft()
        {
            var books = BookDAL.GetThreeBook();
            return PartialView(books);
        }

        [ChildActionOnly]
        public ActionResult MenuTitle()
        {
            var bookCategories = BookCategoryDAL.GetFiveBookCategory();
            return PartialView(bookCategories);
        }

        [ChildActionOnly]
        public ActionResult MenuLeftFooter()
        {
            var publishers = PublisherDAL.GetTenPublisher();
            return PartialView(publishers);
        }
    }
}