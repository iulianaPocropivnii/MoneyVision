using MoneyVision.BusinessLogic.DBModel;
using MoneyVision.Domain.Entities.User.Responses;
using MoneyVision.Domain.Entities.User.Requests;
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
using MoneyVision.Domain.Entities.UserWorkspace;
using System.Net;


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
               User existingUser;

               using (var db = new DatabaseContext())
               {
                    existingUser = db.Users.FirstOrDefault(u => u.Email == data.Email);
               }

               if (existingUser != null)
               {
                    return new URegisterResp { Status = false, StatusMsg = "Email already exists" };
               }

               User user;
               var pass = LoginHelper.HashGen(data.Password);

               Workspace workspace;

               using (var db = new DatabaseContext())
               {
                    workspace = db.Workspaces.Create();
                    workspace.Name = data.Username + " " + "Workspace";

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
                    user.WorkspaceId = workspace.Id;

                    var result = db.Users.Add(user);

                    db.SaveChanges();
               }

               UserWorkspace userWorkspace; 

               using (var db = new DatabaseContext())
               {
                    userWorkspace = db.UserWorkspaces.Create();

                    userWorkspace.UserId = user.Id;
                    userWorkspace.WorkspaceId = workspace.Id;
                    userWorkspace.Level = UserRole.Admin;

                    db.UserWorkspaces.Add(userWorkspace);
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
               userminimal.Email = curentUser.Email;
               userminimal.WorkspaceId = curentUser.WorkspaceId;

               return userminimal;
          }
          internal UserMinimal UserCookie(string cookie, int workspaceId)
          {
               Session session;
               User curentUser;
               UserWorkspace userWorkspace;

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

               using (var db = new DatabaseContext())
               {
                    userWorkspace = db.UserWorkspaces.FirstOrDefault(uw => uw.UserId == curentUser.Id && uw.WorkspaceId == workspaceId);
               }

               if (userWorkspace == null) return null;

               var userminimal = new UserMinimal();
               userminimal.Username = curentUser.Username;
               userminimal.Id = curentUser.Id;
               userminimal.Level = userWorkspace.Level;
               userminimal.Email = curentUser.Email;
               userminimal.WorkspaceId = curentUser.WorkspaceId;

               return userminimal;
          }
          internal UProfileResp UserProfileAction(UProfileData data, UserMinimal currentUser)
          {
               var response = new UProfileResp();

               if (currentUser == null)
               {
                    response.Status = false;
                    response.StatusMsg = "User not found in session";
                    return response;
               }

               using (var db = new DatabaseContext())
               {
                    var user = db.Users.FirstOrDefault(u => u.Id == currentUser.Id);

                    if (user == null)
                    {
                         response.Status = false;
                         response.StatusMsg = "User not found";
                         return response;
                    }

                    if (!string.IsNullOrWhiteSpace(data.NewUsername))
                    {
                         user.Username = data.NewUsername;
                    }


                    if (!string.IsNullOrWhiteSpace(data.CurrentPassword) && !string.IsNullOrWhiteSpace(data.NewPassword))
                    {
                         var currentPass = LoginHelper.HashGen(data.CurrentPassword);

                         if (currentPass != user.Password)
                         {
                              response.Status = false;
                              response.StatusMsg = "Incorrect current password";
                              return response;
                         }

                         user.Password = LoginHelper.HashGen(data.NewPassword);
                    }

                    try
                    {
                         db.Entry(user).State = EntityState.Modified;
                         db.SaveChanges();
                         response.Status = true;
                         response.StatusMsg = "Profile updated successfully";
                    }
                    catch (Exception ex)
                    {
                         response.Status = false;
                         response.StatusMsg = "An error occurred: " + ex.Message;
                    }
               }

               return response;
          }
          internal UProfileResp UserLogoutAction(UserMinimal currentUser)
          {
               Session session;

               using (var db = new DatabaseContext())
               {
                    session = db.Sessions.FirstOrDefault(u => u.Id == currentUser.Id);
                    
                    db.Sessions.Remove(session);
                    db.SaveChanges();
               }

               var apiCookie = new HttpCookie("X-KEY")
               {
                    Value = "",
                    Expires = DateTime.Now.AddYears(-1)
               };
               HttpContext.Current.Response.Cookies.Add(apiCookie);

               return new UProfileResp();
          }


     }

}


