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
using MoneyVision.Domain.Entities.Workspace;

namespace MoneyVision.BusinessLogic.Core
{
     public class UserApi
     {
          internal ULoginResp UserLoginAction(ULoginData data)
          {
               User result;
               var validate = new EmailAddressAttribute();
               if (validate.IsValid(data.Email))
               {
                    var pass = LoginHelper.HashGen(data.Password);
                    using (var db = new DatabaseContext())
                    {
                         result = db.Users.FirstOrDefault(u => u.Email == data.Email && u.Password == pass);
                    }

                    if (result == null)
                    {
                         return new ULoginResp { Status = false, StatusMsg = "The Username or Password is Incorrect" };
                    }

                    using (var todo = new DatabaseContext())
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
                    using (var db = new DatabaseContext())
                    {
                         result = db.Users.FirstOrDefault(u => u.Username == data.Email && u.Password == pass);
                    }

                    if (result == null)
                    {
                         return new ULoginResp { Status = false, StatusMsg = "The Username or Password is Incorrect" };
                    }

                    using (var todo = new DatabaseContext())
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
               User user;
               var pass = LoginHelper.HashGen(data.Password);

               Workspace workspace;

               using (var db = new DatabaseContext())
               {
                    workspace = db.Workspaces.Create();

                    db.Workspaces.Add(workspace);
                    db.SaveChanges();
               }

               if (workspace == null)
                    return new URegisterResp { Status = false };

               using (var db = new DatabaseContext())
               {
                    user = db.Users.Create();
                    user.Email = data.Email;
                    user.Username = data.Username;
                    user.Password = pass;
                    user.Level = UserRole.Admin;
                    user.WorkspaceId = workspace.Id;

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


          internal HttpCookie Cookie(string loginEmail)
          {
               var apiCookie = new HttpCookie("X-KEY")
               {
                    Value = CookieGenerator.Create(loginEmail)
               };

               using (var db = new DatabaseContext())
               {
                    Session curent;
                    var validate = new EmailAddressAttribute();
                    if (validate.IsValid(loginEmail))
                    {
                         curent = (from e in db.Sessions where e.Email == loginEmail select e).FirstOrDefault();
                    }
                    else
                    {
                         curent = (from e in db.Sessions where e.Email == loginEmail select e).FirstOrDefault();
                    }

                    if (curent != null)
                    {
                         curent.CookieString = apiCookie.Value;
                         curent.ExpireTime = DateTime.Now.AddMinutes(60);
                         using (var todo = new DatabaseContext())
                         {
                              todo.Entry(curent).State = EntityState.Modified;
                              todo.SaveChanges();
                         }
                    }
                    else
                    {
                         db.Sessions.Add(new Session
                         {
                              Email = loginEmail,
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
               User curentUser;

               using (var db = new DatabaseContext())
               {
                    session = db.Sessions.FirstOrDefault(s => s.CookieString == cookie && s.ExpireTime > DateTime.Now);
               }

               if (session == null) return null;
               using (var db = new DatabaseContext())
               {
                    var validate = new EmailAddressAttribute();
                    if (validate.IsValid(session.Email))
                    {
                         curentUser = db.Users.FirstOrDefault(u => u.Email == session.Email);
                    }
                    else
                    {
                         curentUser = db.Users.FirstOrDefault(u => u.Username == session.Email);
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
