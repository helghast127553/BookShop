using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BookShop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
            name: "Update Cart",
            url: "cap-nhat-gio-hang",
            defaults: new { controller = "Cart", action = "UpdateCart", id = UrlParameter.Optional }
          );

            routes.MapRoute(
            name: "Add Cart",
            url: "them-gio-hang",
            defaults: new { controller = "Cart", action = "AddBook", id = UrlParameter.Optional }
          );

            routes.MapRoute(
            name: "Cart",
            url: "gio-hang",
            defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional }
          );

            routes.MapRoute(
            name: "Logout",
            url: "dang-xuat",
            defaults: new { controller = "User", action = "Logout", id = UrlParameter.Optional }
          );

            routes.MapRoute(
            name: "Register",
            url: "dang-ky",
            defaults: new { controller = "User", action = "Register", id = UrlParameter.Optional }
          );

            routes.MapRoute(
            name: "Login",
            url: "dang-nhap",
            defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional }
          );

            routes.MapRoute(
            name: "Others Book Publisher",
            url: "nha-xuat-ban-khac",
            defaults: new { controller = "Book", action = "OthersBookPublisher", id = UrlParameter.Optional },
            namespaces: new[] { "BookShop.Controllers" }
          );

            routes.MapRoute(
            name: "Book Publishers",
            url: "sach/{MetaTitle}-{ID}",
            defaults: new { controller = "Book", action = "BooksPublisher", id = UrlParameter.Optional },
            namespaces: new[] { "BookShop.Controllers" }
          );

            routes.MapRoute(
             name: "Others Book Category",
             url: "chu-de-khac",
             defaults: new { controller = "Book", action = "OthersBookCategory", id = UrlParameter.Optional },
             namespaces: new[] { "BookShop.Controllers" }
          );

            routes.MapRoute(
              name: "Book Category",
              url: "sach/{MetaTitle}-{ID}",
              defaults: new { controller = "Book", action = "BooksCategory", id = UrlParameter.Optional },
              namespaces: new[] { "BookShop.Controllers" }
           );

            routes.MapRoute(
            name: "Book Detail",
            url: "chi-tiet/{MetaTitle}-{ID}",
            defaults: new { controller = "Book", action = "BookDetail", id = UrlParameter.Optional },
            namespaces: new[] { "BookShop.Controllers" }
        );

            routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            namespaces: new [] { "BookShop.Controllers" }
         );
        }
    }
}
