using BookShop.Areas.Admin.Models;
using BookShop.Common;
using BookShop.Models.DAL;
using BookShop.Models.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShop.Areas.Admin.Controllers
{
    public class BookController : BaseController
    {
        // GET: Admin/Book
        [HttpGet]
        public ActionResult Index()
        {
            var books = BookDAL.GetBooks();
            return View(books);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.BookCategories = new SelectList(BookCategoryDAL.GetBookCategories(), "ID", "Name") ;
            ViewBag.Publishers = new SelectList(PublisherDAL.GetPublishers(), "ID", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(BookModel bookModel, HttpPostedFileBase fileUpload)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileName(fileUpload.FileName);
                fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                if (System.IO.File.Exists(fileName))
                {
                    ModelState.AddModelError("", "Ảnh bìa đã tồn tại");
                }
                else
                {
                    fileUpload.SaveAs(fileName);
                }
                var book = new Book
                {
                    Name = bookModel.Name,
                    MetaTitle = StringHelper.ToUnsignString(bookModel.Name),
                    Image = fileUpload.FileName,
                    Price = bookModel.Price,
                    Description = HttpUtility.HtmlEncode(bookModel.Description),
                    Quantity = bookModel.Quantity,
                    PublisherID = bookModel.PublisherID,
                    BookCategoryID = bookModel.BookCategoryID,
                   Status = bookModel.Status
                };
                if (BookDAL.InsertBook(book) > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm sách mới thành công");
                }
            }
            return View(bookModel);
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var book = BookDAL.GetBook(ID);
            var bookModel = new BookModel
            {
                ID = ID,
                Name = book.Name,
                ImagePath = book.Image,
                Price = book.Price.Value,
                Description = book.Description,
                Quantity = book.Quantity.Value,
                Status = book.Status
            };
            ViewBag.BookCategories = new SelectList(BookCategoryDAL.GetBookCategories(), "ID", "Name", book.BookCategoryID.Value);
            ViewBag.Publishers = new SelectList(PublisherDAL.GetPublishers(), "ID", "Name", book.PublisherID.Value);
            return View(bookModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(BookModel bookModel, HttpPostedFileBase fileUpload)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileName(fileUpload.FileName);
                fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                if (System.IO.File.Exists(fileName))
                {
                    ModelState.AddModelError("", "Ảnh bìa đã tồn tại");
                }
                else
                {
                    fileUpload.SaveAs(fileName);
                }
                var book = new Book
                {
                    Name = bookModel.Name,
                    MetaTitle = StringHelper.ToUnsignString(bookModel.Name),
                    Image = fileUpload.FileName,
                    Price = bookModel.Price,
                    Description = HttpUtility.HtmlEncode(bookModel.Description),
                    Quantity = bookModel.Quantity,
                    PublisherID = bookModel.PublisherID,
                    BookCategoryID = bookModel.BookCategoryID
                };
                if (BookDAL.UpdateBook(book) > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm sách mới thành công");
                }
            }
            return View(bookModel);
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            bool status = false;
            if (BookDAL.DeleteBook(ID) > 0)
            {
                status = true;
            }
            return Json(status, JsonRequestBehavior.AllowGet);
        }
    }
}