using MoneyVision.BusinessLogic.Core;
using MoneyVision.BusinessLogic.Interfaces;
using MoneyVision.Domain.Entities.User;
namespace MoneyVision.BusinessLogic
{
     public class SessionBL: UserApi, ISession
     {
          public ULoginData UserLogin(ULoginData _login)
          {
               return _login;
          }
        public URegisterData UserRegister(URegisterData _register) 
        {
            return _register;
        }

     }
}
