using MoneyVision.BusinessLogic.DBModel;
using MoneyVision.Domain.Entities.User.Responses;
using MoneyVision.Domain.Entities.User;
using System.Linq;
using System.Web;
using System.Diagnostics;
using MoneyVision.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System;
using MoneyVision.Domain.Enums;

namespace MoneyVision.BusinessLogic.Core
{
    public class UserApi
    {
        internal ULoginResp UserLoginAction(ULoginData data)
        {
            UDbTable result;
            var validate = new EmailAddressAttribute();
            if (validate.IsValid(data.Credential))
            {
                var pass = LoginHelper.HashGen(data.Password);
                using (var db = new UserContext())
                {
                    result = db.Users.FirstOrDefault(u => u.Email == data.Credential && u.Password == pass);
                }

                if (result == null)
                {
                    return new ULoginResp { Status = false, StatusMsg = "The Username or Password is Incorrect" };
                }

                using (var todo = new UserContext())
                {
                    result.LastIp = data.LoginIp;
                    result.LastLogin = data.LoginDateTime;
                    todo.Entry(result).State = EntityState.Modified;
                    todo.SaveChanges();
                }

                return new ULoginResp { Status = true };
            }
            else
            {
                var pass = LoginHelper.HashGen(data.Password);
                using (var db = new UserContext())
                {
                    result = db.Users.FirstOrDefault(u => u.Username == data.Credential && u.Password == pass);
                }

                if (result == null)
                {
                    return new ULoginResp { Status = false, StatusMsg = "The Username or Password is Incorrect" };
                }

                using (var todo = new UserContext())
                {
                    result.LastIp = data.LoginIp;
                    result.LastLogin = data.LoginDateTime;
                    todo.Entry(result).State = EntityState.Modified;
                    todo.SaveChanges();
                }

                return new ULoginResp { Status = true };
            }
        }
        public URegisterResp UserRegisterAction(URegisterData data)
        {
            Debug.WriteLine(data.Email);
            Debug.WriteLine(data.Credential);
            Debug.WriteLine(data.Password);
       
            UDbTable user;
            var pass = LoginHelper.HashGen(data.Password);
          
            using (var db = new UserContext())
            {
                user = db.Users.Create();
                user.Email = data.Email;
                user.Username = data.Credential;
                user.Password = pass;
                user.Level = URole.Admin;


                var result = db.Users.Add(user);

                db.SaveChanges();
                
            }
            if (user != null)
            {
                return new URegisterResp { Status = true };
            }
            else
            {
                return new URegisterResp { Status = false };
            }
        }


        internal HttpCookie Cookie(string loginCredential)
        {
            var apiCookie = new HttpCookie("X-KEY")
            {
                Value = CookieGenerator.Create(loginCredential)
            };

            using (var db = new SessionContext())
            {
                Session curent;
                var validate = new EmailAddressAttribute();
                if (validate.IsValid(loginCredential))
                {
                    curent = (from e in db.Sessions where e.Username == loginCredential select e).FirstOrDefault();
                }
                else
                {
                    curent = (from e in db.Sessions where e.Username == loginCredential select e).FirstOrDefault();
                }

                if (curent != null)
                {
                    curent.CookieString = apiCookie.Value;
                    curent.ExpireTime = DateTime.Now.AddMinutes(60);
                    using (var todo = new SessionContext())
                    {
                        todo.Entry(curent).State = EntityState.Modified;
                        todo.SaveChanges();
                    }
                }
                else
                {
                    db.Sessions.Add(new Session
                    {
                        Username = loginCredential,
                        CookieString = apiCookie.Value,
                        ExpireTime = DateTime.Now.AddMinutes(60)
                    });
                    db.SaveChanges();
                }
            }

            return apiCookie;
        }

        internal UserMinimal UserCookie(string cookie)
        {
            Session session;
            UDbTable curentUser;

            using (var db = new SessionContext())
            {
                session = db.Sessions.FirstOrDefault(s => s.CookieString == cookie && s.ExpireTime > DateTime.Now);
            }

            if (session == null) return null;
            using (var db = new UserContext())
            {
                var validate = new EmailAddressAttribute();
                if (validate.IsValid(session.Username))
                {
                    curentUser = db.Users.FirstOrDefault(u => u.Email == session.Username);
                }
                else
                {
                    curentUser = db.Users.FirstOrDefault(u => u.Username == session.Username);
                }
            }

            if (curentUser == null) return null;
            var userminimal = new UserMinimal();
            userminimal.Username = curentUser.Username;
            userminimal.Id = curentUser.Id;
            userminimal.Level = curentUser.Level;
            userminimal.Email = curentUser.Email;

            return userminimal;
        }
    }
}
