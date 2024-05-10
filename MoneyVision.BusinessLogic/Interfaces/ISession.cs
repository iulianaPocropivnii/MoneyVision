using MoneyVision.Domain.Entities.User;
using MoneyVision.Domain.Entities.User.Responses;
using MoneyVision.Domain.Entities.User.Requests;
using System.Web;
using MoneyVision.Domain.Entities.Transaction.Requests;
using MoneyVision.Domain.Entities.Transaction.Responses;
using MoneyVision.Domain.Entities.Workspace.Requests;
using MoneyVision.Domain.Entities.Workspace.Response;

namespace MoneyVision.BusinessLogic.Interfaces
{
     public interface ISession
     {
          ULoginResp UserLoginAction(ULoginData data);
          URegisterResp UserRegisterAction(URegisterData data);
          HttpCookie GenCookie(string loginCredential);
          UserMinimal GetUserByCookie(string apiCookieValue);
          UserMinimal GetUserByCookie(string apiCookieValue, int worksapceId);
          UProfileResp UserProfileAction(UProfileData data, UserMinimal _currentUser);

          TransactionsListResp TransactionsListAction(TransactionsListData data);

          WorkspacesListResp WorkspacesListAction(WorkspacesListData data);
     }
}
