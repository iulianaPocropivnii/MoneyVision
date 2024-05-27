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
using MoneyVision.Domain.Entities.Category.Responses;
using MoneyVision.Domain.Entities.Category.Requests;

using MoneyVision.Domain.Entities;
using MoneyVision.Domain.Enums;
namespace MoneyVision.BusinessLogic
{
     public class SessionBL : ISession
     {
          private readonly UserApi userApi;
          private readonly TransactionApi transactionApi;
          private readonly WorkspaceApi workspaceApi;
        private readonly CategoriesApi categoriesApi;

          public SessionBL()
          {
               this.userApi = new UserApi();
               this.transactionApi = new TransactionApi();
               this.workspaceApi = new WorkspaceApi();
               this.categoriesApi = new CategoriesApi();
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
          public TransactionsCreateResp TransactionsCreateAction(TransactionsCreateData data)
          {
               return this.transactionApi.TransactionsCreateAction(data);
          }
          public CategoriesListResp CategoriesListAction(CategoriesListData data)
          {
               return this.categoriesApi.CategoriesListAction(data);
          }
          public WorkspacesListResp WorkspacesListAction(WorkspacesListData data)
          {
               return this.workspaceApi.WorkspacesListAction(data);
          }

          public void UserLogoutAction(UserMinimal currentUser)
          {
               this.userApi.UserLogoutAction(currentUser);
          }

          public GenericResp AddUserAction(UAddData data)
          {
               return this.userApi.AddUserAction(data);
          }
     }
}
