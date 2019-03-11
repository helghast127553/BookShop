using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Common
{
    public static class CommonConstants
    {
        public static string USER_SESSION = "USER_SESSION";
        public static string CART_SESSION = "CART_SESSION";
        public static string SESSION_CREDENTIALS = "";
        public static string CURRENT_CULTURE { get; set; }
        public static string MEMBER_GROUP = "MEMBER";
        public static string ADMIN_GROUP = "ADMIN";
        public static string MOD_GROUP = "MOD";
    }
}