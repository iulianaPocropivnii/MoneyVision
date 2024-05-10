using MoneyVision.Domain.Entities.User;
using MoneyVision.Domain.Entities.User.Responses;
using MoneyVision.Domain.Entities.User.Requests;
using System.Web;
using MoneyVision.Domain.Entities.Transaction.Requests;
using MoneyVision.Domain.Entities.Transaction.Responses;

namespace MoneyVision.BusinessLogic.Interfaces
{
     public interface ISession
     {
          ULoginResp UserLoginAction(ULoginData data);
          URegisterResp UserRegisterAction(URegisterData data);
          HttpCookie GenCookie(string loginCredential);
          UserMinimal GetUserByCookie(string apiCookieValue);
          UProfileResp UserProfileAction(UProfileData data, UserMinimal _currentUser);

          TransactionsListResp TransactionsListAction(TransactionsListData data);
     }
}
