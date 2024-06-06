using MoneyVision.Domain.Entities.User;
using MoneyVision.Domain.Entities.User.Responses;
using MoneyVision.Domain.Entities.User.Requests;
using System.Web;
using MoneyVision.Domain.Entities.Transaction.Requests;
using MoneyVision.Domain.Entities.Transaction.Responses;
using MoneyVision.Domain.Entities.Workspace.Requests;
using MoneyVision.Domain.Entities.Workspace.Response;
using MoneyVision.Domain.Entities.Category.Requests;
using MoneyVision.Domain.Entities.Category.Responses;
using MoneyVision.Domain.Entities;
using MoneyVision.Domain.Enums;
using System.Collections.Generic;


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
          void UserLogoutAction(UserMinimal _currentUser);
          UAddResp AddUserAction(UAddData data);
          TransactionsListResp TransactionsListAction(TransactionsListData data);
          TransactionItemResp TransactionItemAction(TransactionItemData data);
          TransactionsCreateResp TransactionsCreateAction(TransactionsCreateData data);
          TransactionsUpdateResp TransactionsUpdateAction(TransactionsUpdateData data);
          TransactionDeleteItemResp TransactionDeleteItemAction(TransactionDeleteItemData data);
          CategoriesListResp CategoriesListAction(CategoriesListData data);
          GenericResp AddCategoryAction(CategoryAddData data);
          WorkspacesListResp WorkspacesListAction(WorkspacesListData data);
          UListResp UsersListAction(UListData data);
     }
}
