using BookShop.Models.DAL;
using BookShop.Models.DTO;
using BookShop.Models.EF;
//using BotDetect.Web.Mvc;
using BookShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShop.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[CaptchaValidation("CaptchaCode", "RegistrationCaptcha", "Mã xác nhận không đúng!")]
        public ActionResult Register(RegisterDTO registerDTO)
        {
            if (ModelState.IsValid)
            {
                if (UserDAL.CheckUserName(registerDTO.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else if (UserDAL.CheckEmail(registerDTO.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                }
                else
                {
                    var user = new User
                    {
                        Name = registerDTO.Name,
                        UserName = registerDTO.UserName,
                        Password = Encryptor.MD5Hash(registerDTO.Password),
                        Address = registerDTO.Address,
                        Email = registerDTO.Email,
                        Phone = registerDTO.Phone,
                        Status = true
                    };
                    if (UserDAL.InsertUser(user) > 0)
                    {
                        return Login(new LoginDTO { UserName = registerDTO.UserName, Password = registerDTO.Password });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công");
                    }
                }

            }
            return View(registerDTO);

        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginDTO loginDTO)
        {
            if (ModelState.IsValid)
            {
                var result = UserDAL.CheckUser(loginDTO.UserName, Encryptor.MD5Hash(loginDTO.Password));
                if (result == 1)
                {
                    var user = UserDAL.GetUserByID(loginDTO.UserName);
                    Session[CommonConstants.USER_SESSION] = new UserLogin { UserID = user.ID, UserName = loginDTO.UserName };
                    return Redirect("/");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản đăng nhập không tồn tại");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đăng nhập bị khóa");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không đúng ");
                }
            }
            return View(loginDTO);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return Redirect("/");
        }
    }
}