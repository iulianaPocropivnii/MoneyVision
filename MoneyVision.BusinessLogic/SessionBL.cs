using MoneyVision.BusinessLogic.Core;
using MoneyVision.BusinessLogic.Interfaces;
using MoneyVision.Domain.Entities.User;
using MoneyVision.Domain.Entities.User.Responses;
using MoneyVision.Domain.Entities.User.Requests;
using System.Web;
using MoneyVision.Domain.Entities.Transaction.Responses;
using MoneyVision.Domain.Entities.Transaction.Requests;
using MoneyVision.Domain.Entities.Workspace.Response;
using MoneyVision.Domain.Entities.Workspace.Requests;
namespace MoneyVision.BusinessLogic
{
     public class SessionBL : ISession
     {
          private readonly UserApi userApi;
          private readonly TransactionApi transactionApi;
          private readonly WorkspaceApi workspaceApi;

          public SessionBL()
          {
               this.userApi = new UserApi();
               this.transactionApi = new TransactionApi();
               this.workspaceApi = new WorkspaceApi();
          }

          public ULoginResp UserLoginAction(ULoginData _login)
          {
               return this.userApi.UserLoginAction(_login);
          }
          public URegisterResp UserRegisterAction(URegisterData _register)
          {
               return this.userApi.UserRegisterAction(_register);
          }
          public HttpCookie GenCookie(string loginCredential)
          {
               return this.userApi.Cookie(loginCredential);
          }

          public UserMinimal GetUserByCookie(string apiCookieValue)
          {
               return this.userApi.UserCookie(apiCookieValue);
          }
          public UserMinimal GetUserByCookie(string apiCookieValue, int worksapceId)
          {
               return this.userApi.UserCookie(apiCookieValue);
          }
          public UProfileResp UserProfileAction(UProfileData _profile, UserMinimal _currentUser)
          {
               return this.userApi.UserProfileAction(_profile, _currentUser);
          }

          public TransactionsListResp TransactionsListAction(TransactionsListData data)
          {
               return this.transactionApi.TransactionsListAction(data);
          }

          public WorkspacesListResp WorkspacesListAction(WorkspacesListData data)
          {
               return this.workspaceApi.WorkspacesListAction(data);
          }

          public UProfileResp UserLogoutAction(UserMinimal currentUser)
          {
               return this.userApi.UserLogoutAction(currentUser);
          }
     }
}
