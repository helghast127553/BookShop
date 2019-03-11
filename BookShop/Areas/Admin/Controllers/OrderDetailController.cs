using BookShop.Areas.Admin.Models;
using BookShop.Models.DAL;
using BookShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShop.Areas.Admin.Controllers
{
    public class OrderDetailController : BaseController
    {
        // GET: Admin/OrderDetail
        [HttpGet]
        public ActionResult Index()
        {
            var orderDetails = OrderDetailDAL.GetOrderDetails();
            return View(orderDetails);
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrderDetailModel orderDetailModel)
        {
            if (ModelState.IsValid)
            {
                var orderDetail = new OrderDetail
                {
                    OrderID = orderDetailModel.OrderID,
                    BookID = orderDetailModel.BookID,
                    Quantity = orderDetailModel.Quantity,
                    Price = orderDetailModel.Price,
                    TotalPrice = orderDetailModel.TotalPrice
                };
                if (OrderDetailDAL.UpdateOrderDetail(orderDetail) > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật chi tiết đơn hàng không thành công");
                }
            }
            return View(orderDetailModel);
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            bool status = false;
            if (UserDAL.DeleteUser(ID) > 0)
            {
                status = true;
            }
            return Json(status, JsonRequestBehavior.AllowGet); return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}