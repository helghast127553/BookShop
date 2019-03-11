using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookShop.Areas.Admin.Models
{
    public class BookModel
    {
        public int ID { get; set; }
        [Display(Name = "Tên sách")]
        [Required(ErrorMessage = "Tên sách không dược để trống")]
        public string Name { get; set; }

        [Display(Name = "Ảnh bìa:")]
        public string ImagePath { get; set; }

        [Display(Name = "Giá sách:")]
        [DisplayFormat(DataFormatString = "{0:0,0}", ApplyFormatInEditMode = true)]
        [RegularExpression("([0-9]+)", ErrorMessage = "Giá sách phải nhập số")]
        [Required(ErrorMessage = "Tên sách không dược để trống")]
        public Nullable<decimal> Price { get; set; }

        [Display(Name = "Mô tả sách:")]
        [Required(ErrorMessage = "Mô tả sách không dược để trống")]
        public string Description { get; set; }

        [Display(Name = "Số lượng:")]
        [Range(1, 100, ErrorMessage = "Số lượng sách không được quá 100 cuốn")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Số lượng phải nhập số")]
        [Required(ErrorMessage = "Số lượng không dược để trống")]
        public Nullable<int> Quantity { get; set; }

        [Display(Name = "Nhà xuất bản:")]
        public Nullable<int> PublisherID { get; set; }

        [Display(Name = "Chủ đề sách:")]
        public Nullable<int> BookCategoryID { get; set; }
        public Nullable<bool> Status { get; set; }
    }
}