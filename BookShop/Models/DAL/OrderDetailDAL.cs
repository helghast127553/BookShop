using BookShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Models.DAL
{
    public static class OrderDetailDAL
    {
        public static int InsertOrderDetail(OrderDetail orderDetail)
        {
            using (var db = new BookShopEntities())
            {
                db.OrderDetails.Add(orderDetail);
                var result = db.SaveChanges();
                return result;
            }
        }

        public static int UpdateOrderDetail(OrderDetail orderDetailEntity)
        {
            using (var db = new BookShopEntities())
            {
                var orderDetails = db.OrderDetails.Find(orderDetailEntity.ID);
                orderDetails.OrderID = orderDetailEntity.OrderID;
                orderDetails.BookID = orderDetailEntity.BookID;
                orderDetails.Quantity = orderDetailEntity.Quantity;
                orderDetails.Price = orderDetailEntity.Price;
                orderDetails.TotalPrice = orderDetailEntity.TotalPrice;
                var result = db.SaveChanges();
                return result;
            }
        }

        public static int DeleteOrderDetail(int ID)
        {
            using (var db = new BookShopEntities())
            {
                var orderDetail = db.OrderDetails.Find(ID);
                db.OrderDetails.Remove(orderDetail);
                var result = db.SaveChanges();
                return result;
            }
        }

        public static List<OrderDetail> GetOrderDetails()
        {
            using (var db = new BookShopEntities())
            {
                var orderDetails = db.OrderDetails.ToList();
                return orderDetails;
            }
        }
    }
}