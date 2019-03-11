using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookShop.Areas.Admin.Models
{
    public class OrderDetailModel
    {
        public int ID { get; set; }

        [Display(Name = "Mã đơn hàng:")]
        [Required(ErrorMessage = "Mã đơn hàng không dược để trống")]
        public Nullable<int> OrderID { get; set; }

        [Display(Name = "Mã sách:")]
        [Required(ErrorMessage = "Mã sách không dược để trống")]
        public Nullable<int> BookID { get; set; }

        [Display(Name = "Số lượng:")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Số lượng phải nhập số")]
        [Required(ErrorMessage = "Số lượng không dược để trống")]
        public Nullable<int> Quantity { get; set; }

        [Display(Name = "Giá sách:")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Giá sách phải nhập số")]
        [Required(ErrorMessage = "Giá sách không dược để trống")]
        public Nullable<decimal> Price { get; set; }

        [Display(Name = "Tổng giá sách:")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Tổng giá sách phải nhập số")]
        [Required(ErrorMessage = "Tổng giá sách không dược để trống")]
        public Nullable<decimal> TotalPrice { get; set; }
    }
}