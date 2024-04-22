using MoneyVision.BusinessLogic.Core;
using MoneyVision.BusinessLogic.Interfaces;
using MoneyVision.Domain.Entities.User;
using MoneyVision.Domain.Entities.User.Responses;
using System.Web;
namespace MoneyVision.BusinessLogic
{
     public class SessionBL : UserApi, ISession
     {
          public ULoginResp UserLoginAction(ULoginData _login)
          {
               return base.UserLoginAction(_login);
          }
        public URegisterResp UserRegisterAction(URegisterData _register) 
        {
            return base.UserRegisterAction(_register);
        }
        public HttpCookie GenCookie(string loginCredential)
        {
            return Cookie(loginCredential);
        }

        public UserMinimal GetUserByCookie(string apiCookieValue)
        {
            return UserCookie(apiCookieValue);
        }

    }
}
