using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookShop.Models.DTO
{
    public class RegisterDTO
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Họ tên:")]
        [Required(ErrorMessage = "Họ tên không được để trống")]
        public string Name { get; set; }

        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        public string UserName { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Độ dài mật khẩu phải ít nhất 6 kí tự")]
        public string Password { get; set; }

        [Display(Name = "Xác nhận mật khẩu:")]
        [Required(ErrorMessage = "Xác nhận mật khẩu không được để trống")]
        [Compare("Password", ErrorMessage = "Xác nhận mật khẩu không đúng")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Địa chỉ:")]
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Địa chỉ phải ít nhất 6 kí tự")]
        public string Address { get; set; }

        [Display(Name = "Email:")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ")]
        public string Email { get; set; }

        [Display(Name = "Số điện thoại:")]
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [Phone(ErrorMessage = "Số điện thoại phải nhập số")]
        [RegularExpression(@"^([0-9]{10,11})$", ErrorMessage = "Số điện thoại phải từ 10 tới 11 số")]
        public string Phone { get; set; }
    }
}