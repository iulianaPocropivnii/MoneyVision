using MoneyVision.BusinessLogic.DBModel;
using MoneyVision.Domain.Entities.User.Responses;
using MoneyVision.Domain.Entities.User;
using System.Linq;
using System;
using System.Diagnostics;

namespace MoneyVision.BusinessLogic.Core
{
     public class UserApi
     {
          public ULoginResp UserLoginAction(ULoginData data)
          {
               UDbTable user;
               using (var db = new UserContext())
               {
                    user = db.Users.FirstOrDefault(u => u.Email == data.Credential && u.Password == data.Password);
               }
               if (user != null)
               {
                    return new ULoginResp { Status = true };
               }
               else
               {
                    return new ULoginResp { Status = false };
               }
          }
     }
}
