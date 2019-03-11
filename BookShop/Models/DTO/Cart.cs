using BookShop.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Models.DTO
{
    public class Cart
    {
        public Cart(int bookID)
        {
            var book = BookDAL.GetBook(bookID);
            this.BookID = bookID;
            this.Name = book.Name;
            this.Image = book.Image;
            this.Price = book.Price.Value;
        }
        public int BookID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; } = 1;
        public decimal Price { get; set; }
        public decimal Total
        {
            get
            {
                return this.Quantity * this.Price;
            }
        }
    }
}