using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookShop.Areas.Admin.Models
{
    public class LoginModel
    {
        [Display(Name = "Tài khoản")]
        [Required(ErrorMessage = "Nhập tên đăng nhập của bạn ")]
        public string UserName { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Nhập mật khẩu của bạn")]
        public string Password { get; set; }

        [Display(Name = "Nhớ mật khẩu")]
        public bool RememberMe { get; set; }
    }
}