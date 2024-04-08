using MoneyVision.Domain.Entities.User;
using MoneyVision.Domain.Entities.User.Responses;

namespace MoneyVision.BusinessLogic.Interfaces
{
     public interface ISession
     {
          ULoginResp UserLoginAction(ULoginData data);
        URegisterResp UserRegisterAction(URegisterData data);
    }
}
