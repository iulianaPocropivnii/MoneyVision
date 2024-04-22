using MoneyVision.Domain.Entities.User;
using MoneyVision.Domain.Entities.User.Responses;
using System.Web;

namespace MoneyVision.BusinessLogic.Interfaces
{
     public interface ISession
     {
        ULoginResp UserLoginAction(ULoginData data);
        URegisterResp UserRegisterAction(URegisterData data);
        HttpCookie GenCookie(string loginCredential);
        UserMinimal GetUserByCookie(string apiCookieValue);
    }
}
