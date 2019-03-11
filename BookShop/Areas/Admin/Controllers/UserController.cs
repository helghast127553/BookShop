using BookShop.Areas.Admin.Models;
using BookShop.Common;
using BookShop.Models.DAL;
using BookShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShop.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        [HttpGet]
        public ActionResult Index()
        {
            var users = UserDAL.GetUsers();
            return View(users);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Name = registerModel.Name,
                    UserName = registerModel.UserName,
                    Password = Encryptor.MD5Hash(registerModel.Password),
                    Address = registerModel.Address,
                    Email = registerModel.Email,
                    Phone = registerModel.Phone,
                    Status = registerModel.Status
                };
                if (UserDAL.InsertUser(user) > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm user không thành công");
                }
            }
            return View(registerModel);
        }

        [HttpGet]      
        public ActionResult Edit(int ID)
        {
            var user = UserDAL.GetUser(ID);
            var registerModel = new RegisterModel
            {
                ID = user.ID,
                Name = user.Name,
                UserName = user.UserName,
                Password = user.Password,
                Address = user.Address,
                Email = user.Email,
                Phone = user.Phone,
                Status = user.Status.Value
            };
            return View(registerModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    ID = registerModel.ID,
                    Name = registerModel.Name,
                    UserName = registerModel.UserName,
                    Password = Encryptor.MD5Hash(registerModel.Password),
                    Address = registerModel.Address,
                    Email = registerModel.Email,
                    Phone = registerModel.Phone,
                    Status = registerModel.Status
                };
                if (UserDAL.UpdateUser(user) > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật user không thành công");
                }
            }
            return View(registerModel);
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            bool status = false;
            if (UserDAL.DeleteUser(ID) > 0)
            {
                status = true;
            }
            return Json(status, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ChangeStatus(int ID)
        {
            UserDAL.ChangeStatus(ID);
            return RedirectToAction("Index");
        }
    }
}