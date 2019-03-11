using BookShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Models.DAL
{
    public static class MenuDAL
    {
        public static List<Menu> GetMenuByID(int menuTypeID)
        {
            using (var db = new BookShopEntities())
            {
                var menus = db.Menus.Where(x => (x.MenuTypeID == menuTypeID) && x.Status == true)
                    .OrderBy(x => x.DisplayOrder)
                    .ToList();
                return menus;
            }
        }
    }
}