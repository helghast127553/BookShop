using BookShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Models.DAL
{
    public static class OrderDAL
    {
        public static int InsertOrder(Order order)
        {
            using (var db = new BookShopEntities())
            {
                db.Orders.Add(order);
                var result = db.SaveChanges();
                return result;
            }
        }
    }
}