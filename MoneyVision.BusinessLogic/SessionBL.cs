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
using System.Collections.Generic;
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
          public TransactionsUpdateResp TransactionsUpdateAction(TransactionsUpdateData data)
          {
               return this.transactionApi.TransactionsUpdateAction(data);
          }
          public TransactionItemResp TransactionItemAction(TransactionItemData data)
          {
               return this.transactionApi.TransactionItemAction(data);
          }

          public TransactionDeleteItemResp TransactionDeleteItemAction(TransactionDeleteItemData data)
          {
               return this.transactionApi.TransactionDeleteItemAction(data);
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

          public UAddResp AddUserAction(UAddData data)
          {
               return this.userApi.AddUserAction(data);
          }

          public GenericResp AddCategoryAction(CategoryAddData data)
          {
               return this.categoriesApi.AddCategoryAction(data);
          }
          public CategoryUpdateResp CategoryUpdateAction(CategoryUpdateData data)
          {
            return this.categoriesApi.CategoryUpdateAction(data);
          }
          public CategoryItemResp CategoryItemAction(CategoryItemData data)
          {
            return this.categoriesApi.CategoryItemAction(data);
          }
          public UListResp UsersListAction(UListData data)
          {
               return this.userApi.UsersListAction(data);
          }

          public UDeleteResp UserDeleteAction(UDeleteData data)
          {
               return this.userApi.UserDeleteAction(data);
          }

     }
}
