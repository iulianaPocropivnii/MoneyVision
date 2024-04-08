using MoneyVision.BusinessLogic.Core;
using MoneyVision.BusinessLogic.Interfaces;
using MoneyVision.Domain.Entities.User;
using MoneyVision.Domain.Entities.User.Responses;
namespace MoneyVision.BusinessLogic
{
     public class SessionBL : UserApi, ISession
     {
          public ULoginResp UserLoginAction(ULoginData _login)
          {
               return base.UserLoginAction(_login);
          }
        public URegisterData UserRegister(URegisterData _register) 
        {
            return _register;
        }

     }
}
