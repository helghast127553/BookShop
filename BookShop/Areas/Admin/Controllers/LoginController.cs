using BookShop.Areas.Admin.Models;
using BookShop.Common;
using BookShop.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var result = UserDAL.CheckUser(loginModel.UserName, Encryptor.MD5Hash(loginModel.Password), true);
                var credentials = UserDAL.GetCredentials(loginModel.UserName);
                if (result == 1)
                {
                    var user = UserDAL.GetUserByID(loginModel.UserName);
                    Session[CommonConstants.SESSION_CREDENTIALS] = credentials;
                    Session[CommonConstants.USER_SESSION] = new UserLogin { UserID = user.ID, UserName = user.UserName, UserGroupID = user.UserGroupID };
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đăng nhập đang bị khóa");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng");
                }
                else if(result == -3)
                {
                    ModelState.AddModelError("", "Tài khoản không có quyền truy cấp");
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập không tồn tại");
                }
            }
            return View("Index");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return View("Index");
        }
    }
}