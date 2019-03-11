using BookShop.Common;
using BookShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Models.DAL
{
    public static class UserDAL
    {
        public static int InsertUser(User user)
        {
            using (var db = new BookShopEntities())
            {
                db.Users.Add(user);
                var result = db.SaveChanges();
                return result;
            }
        }

        public static int UpdateUser(User userEntity)
        {
            using (var db = new BookShopEntities())
            {
                var user = db.Users.Find(userEntity.ID);
                user.Name = userEntity.Name;
                user.UserName = userEntity.UserName;
                user.Password = userEntity.Password;
                user.Address = userEntity.Address;
                user.Email = userEntity.Email;
                user.Phone = userEntity.Phone;
                var result = db.SaveChanges();
                return result;
            }
        }

        public static int DeleteUser(int ID)
        {
            using (var db = new BookShopEntities())
            {
                var user = db.Users.Find(ID);
                db.Users.Remove(user);
                var result = db.SaveChanges();
                return result;
            }
        }

        public static User GetUser(int ID)
        {
            using (var db = new BookShopEntities())
            {
                var user = db.Users.Find(ID);
                return user;
            }
        }

        public static List<User> GetUsers()
        {
            using (var db = new BookShopEntities())
            {
                var users = db.Users.ToList();
                return users;
            }
        }

        public static bool CheckUserName(string userName)
        {
            using (var db = new BookShopEntities())
            {
                var isUser = db.Users.Count(x => x.UserName.Equals(userName)) > 0;
                return isUser;
            }
        }

        public static bool CheckEmail(string email)
        {
            using (var db = new BookShopEntities())
            {
                var isEmail = db.Users.Count(x => x.Email.Equals(email)) > 0;
                return isEmail;
            }
        }

        public static int CheckUser(string userName, string password)
        {
            using (var db = new BookShopEntities())
            {
                var user = db.Users.SingleOrDefault(x => x.UserName.Equals(userName));
                if (user == null)
                {
                    return 0;
                }
                else
                {
                    if (user.Status == false)
                    {
                        return -1;
                    }
                    else
                    {
                        if (user.Password == password)
                        {
                            return 1;
                        }
                        else
                        {
                            return -2;
                        }
                    }

                }
            }
        }

        public static int CheckUser(string userName, string password, bool isLoginAdmin = false)
        {
            using (var db = new BookShopEntities())
            {
                var user = db.Users.SingleOrDefault(x => x.UserName.Equals(userName));
                if (user == null)
                {
                    return 0;
                }
                else
                {
                    if (isLoginAdmin == true)
                    {
                        if (user.UserGroupID.Equals(CommonConstants.ADMIN_GROUP)
                            || user.UserGroupID.Equals(CommonConstants.MOD_GROUP))
                        {
                            if (user.Status == false)
                            {
                                return -1;
                            }
                            else
                            {
                                if (user.Password == password)
                                {
                                    return 1;
                                }
                                else
                                {
                                    return -2;
                                }
                            }
                        }
                        else
                        {
                            return -3;
                        }
                    }
                    else
                    {
                        if (user.Status == false)
                        {
                            return -1;
                        }
                        else
                        {
                            if (user.Password == password)
                            {
                                return 1;
                            }
                            else
                            {
                                return -2;
                            }
                        }
                    }
                }
            }
        }

        public static User GetUserByID(string userName)
        {
            using (var db = new BookShopEntities())
            {
                var user = db.Users.SingleOrDefault(x => x.UserName.Equals(userName));
                return user;
            }
        }

        public static List<string> GetCredentials(string userName)
        {
            var db = new BookShopEntities();
            var user = db.Users.SingleOrDefault(x => x.UserName.Equals(userName));
            var data = (from a in db.Credentials
                        join b in db.UserGroups on a.UserGroupID equals b.ID
                        join c in db.Roles on a.RoleID equals c.ID
                        where b.ID == user.UserGroupID
                        select new
                        {
                            RoleID = a.RoleID,
                            UserGroupID = a.UserGroupID
                        }).AsEnumerable().Select(x => new Credential
                        {
                            RoleID = x.RoleID,
                            UserGroupID = x.UserGroupID
                        });
            return data.Select(x => x.RoleID).ToList();
        }

        public static bool ChangeStatus(int ID)
        {
            using (var db = new BookShopEntities())
            {
                var user = db.Users.Find(ID);
                user.Status = !user.Status;
                db.SaveChanges();
                return user.Status.Value;
            }
        }
    }
}