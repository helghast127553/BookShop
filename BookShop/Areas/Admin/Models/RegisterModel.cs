using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookShop.Areas.Admin.Models
{
    public class RegisterModel
    {
        public int ID { get; set; }

        [Display(Name = "Họ tên:")]
        [StringLength(50, ErrorMessage = "Họ tên không được nhập quá 50 kí tự")]
        [Required(ErrorMessage = "Họ tên phải được nhập")]
        public string Name { get; set; }

        [Display(Name = "Tên đăng nhập:")]
        [StringLength(50, ErrorMessage = "Tên đăng nhập không được nhập quá 50 kí tự")]
        [Required(ErrorMessage = "Tên đăng nhập phải được nhập")]
        public string UserName { get; set; }


        [Display(Name = "Mật khẩu:")]
        [StringLength(50, ErrorMessage = "Mật khẩu không được nhập quá 32 kí tự")]
        [Required(ErrorMessage = "Họ tên phải được nhập")]
        public string Password { get; set; }

        [Display(Name = "Địa chỉ:")]
        public string Address { get; set; }

        [Display(Name = "Email")]
        [StringLength(50, ErrorMessage = "Email không được nhập quá 50 kí tự")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ")]
        public string Email { get; set; }

        [Display(Name = "Số điện thoại:")]
        [RegularExpression("^[0-9]{10,11}$", ErrorMessage = "Số điện thoại phải từ 10 số đến 11 số")]
        [Phone(ErrorMessage = "Số điện thoại phải nhập số")]
        public string Phone { get; set; }

        [Display(Name = "Trạng thái:")]
        public bool Status { get; set; }
    }
}