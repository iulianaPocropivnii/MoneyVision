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

        public URegisterResp UserRegisterAction(URegisterData data)
        {

            UDbTable user;
            using (var db = new UserContext())
            {
                user = db.Users.Create();
                user.Email = data.Email;
                user.Username = data.Credential;
                user.Password = data.Password;

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
    }
}
