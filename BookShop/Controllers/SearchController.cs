using BookShop.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace BookShop.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        [HttpPost]
        public ActionResult Search(FormCollection form, int? page)
        {
            string keyword = form["search_box"].ToString();
            ViewBag.Keyword = keyword;
            var books = BookDAL.SearchBooks(keyword);
            var booksInOrder = BookDAL.GetBooksInOrder();
            //Phân trang
            int pageNumber = (page ?? 1);
            int pageSize = 9;
            if (books.Count == 0)
            {
                ViewBag.ErrorMessage = "Không tìm thấy sản phẩm nào";
                return View(booksInOrder.ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ErrorMessage = "Đã tìm thấy " + books.Count + " kết quả!";
            return View(books.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Search(int? page, string keyword)
        {
            ViewBag.Keyword = keyword;
            var books = BookDAL.SearchBooks(keyword);
            var booksInOrder = BookDAL.GetBooksInOrder();
            //Phân trang
            int pageNumber = (page ?? 1);
            int pageSize = 9;
            if (books.Count == 0)
            {
                ViewBag.ErrorMessage = "Không tìm thấy sản phẩm nào";
                return View(booksInOrder.ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ErrorMessage = "Đã tìm thấy " + books.Count + " kết quả!";
            return View(books.ToPagedList(pageNumber, pageSize));
        }
    }
}