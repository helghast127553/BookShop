using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookShop.Common;
using BookShop.Models.DAL;
using BookShop.Models.DTO;
using BookShop.Models.EF;
using Newtonsoft.Json;

namespace BookShop.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart

        public List<Cart> GetCart()
        {
            var cart = Session[CommonConstants.CART_SESSION] as List<Cart>;
            if (cart == null)
            {
                cart = new List<Cart>();
                Session[CommonConstants.CART_SESSION] = cart;
            }
            return cart;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var cart = GetCart();
            return View(cart);
        }

        [HttpGet]
        public ActionResult AddBook(int? id)
        {
            var cart = Session[CommonConstants.CART_SESSION] as List<Cart>;
            if (cart != null)
            {
                var book = cart.Find(x => x.BookID == id.Value);
                if (book != null)
                {
                    book.Quantity++;
                }
                else
                {
                    cart.Add(new Cart(id.Value));
                }
            }
            else
            {
                cart = new List<Cart>
                {
                    new Cart(id.Value)
                };
                Session[CommonConstants.CART_SESSION] = cart;
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult UpdateCart()
        {
            var cart = GetCart();
            return View(cart);
        }

        [HttpGet]
        public ActionResult UpdateBookQuantity(int id, int quantity)
        {
            var cart = Session[CommonConstants.CART_SESSION] as List<Cart>;
            var book = cart.Find(x => x.BookID == id);
            if (book != null)
            {
                book.Quantity = quantity;
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteBook(int bookID)
        {
            var cart = Session[CommonConstants.CART_SESSION] as List<Cart>;
            cart.RemoveAll(x => x.BookID == bookID);
            if (cart.Count == 0)
            {
                return Redirect("/");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Order()
        {
            if (Session[CommonConstants.USER_SESSION] == null || Session[CommonConstants.CART_SESSION].ToString() == "")
            {
                return RedirectToAction("Login", "User");
            }
            if (Session[CommonConstants.CART_SESSION] == null)
            {
                return Redirect("/");
            }

            var user = Session[CommonConstants.USER_SESSION] as UserLogin;
            var cart = Session[CommonConstants.CART_SESSION] as List<Cart>;

            var order = new Order { UserID = user.UserID };
            if (OrderDAL.InsertOrder(order) > 0)
            {
                OrderDetail orderDetail = null;
                int result = 0;
                for (int i = 0; i < cart.Count; i++)
                {
                    orderDetail = new OrderDetail
                    {
                        OrderID = order.ID,
                        BookID = cart[i].BookID,
                        Quantity = cart[i].Quantity,
                        Price = cart[i].Price,
                        TotalPrice = cart[i].Total
                    };
                    result = OrderDetailDAL.InsertOrderDetail(orderDetail);
                }
                if (result > 0)
                {
                    Session[CommonConstants.CART_SESSION] = null;
                    return Redirect("/");
                }
            }
;            return Redirect("/");
        }
    }
}