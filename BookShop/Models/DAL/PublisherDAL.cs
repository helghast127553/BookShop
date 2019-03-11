using BookShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Models.DAL
{
    public static class PublisherDAL
    {
        public static List<Publisher> GetTenPublisher()
        {
            using (var db = new BookShopEntities())
            {
                var publishers = db.Publishers.Take(10).OrderBy(x => x.Name).ToList();
                return publishers;
            }           
        }

        public static List<Publisher> GetPublishers()
        {
            using (var db = new BookShopEntities())
            {
                var publishers = db.Publishers.OrderBy(x => x.DisplayOrder).ToList();
                return publishers;
            }
        }

        public static int GetBookPublisher()
        {
            using (var db = new BookShopEntities())
            {
                var publisher = db.Publishers.ToList().ElementAt(0).ID;
                return publisher;
            }
        }

        public static string GetBookPublisher(int ID)
        {
            using (var db = new BookShopEntities())
            {
                var nameBookPublisher = db.Publishers.Find(ID).Name;
                return nameBookPublisher;
            }
        }
    }
}