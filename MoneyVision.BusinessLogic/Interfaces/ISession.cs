using MoneyVision.Domain.Entities.User;

namespace MoneyVision.BusinessLogic.Interfaces
{
     public interface ISession
     {
          ULoginData UserLogin(ULoginData _login);
        URegisterData UserRegister(URegisterData _register);
     }
}
