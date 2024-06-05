using Microsoft.Ajax.Utilities;
using MoneyVision.Domain.Entities.Category.Requests;
using MoneyVision.Domain.Entities.Transaction.Requests;
using MoneyVision.Web.Extension;
using System.Diagnostics;
using System.Web.Mvc;

namespace MoneyVision.Web.Controllers
{
    public  class Parameters
     {
          public int workspaceId;
          public int transactionId;
     }

     public class TransactionsController : BaseController
     {
          // GET: Transactions
          public ActionResult Index(int workspaceId)
          {
               SessionStatus(workspaceId);
               if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
               {
                    return RedirectToAction("Index", "Login");
               }

               TransactionsListData transactionsListData = new TransactionsListData { WorkspaceId = workspaceId };

               var responseData = _session.TransactionsListAction(transactionsListData);

               ViewBag.CreateUrl = "/Workspaces/" + workspaceId + "/Transactions/Create";
               ViewBag.WorkspaceId = workspaceId;

               return View(responseData);
          }

          public ActionResult Create(int workspaceId)
          {
               SessionStatus(workspaceId);
               if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
               {
                    return RedirectToAction("Index", "Login");
               }

               CategoriesListData categoriesListData = new CategoriesListData { WorkspaceId = workspaceId };

               var responseData = _session.CategoriesListAction(categoriesListData);

               ViewBag.FormAction = "/Workspaces/" + workspaceId + "/Transactions/Create";

               return View(responseData);
          }

          [HttpPost]
          public ActionResult Create(int workspaceId, TransactionsCreateData data)
          {
               SessionStatus(workspaceId);
               if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
               {
                    return RedirectToAction("Index", "Login");
               }

               data.WorkspaceId = workspaceId;

               var responseData = _session.TransactionsCreateAction(data);

               return Redirect("/Workspaces/" + workspaceId + "/Transactions/Index");
          }

          public ActionResult Update(int workspaceId, int id)
          {
               SessionStatus(workspaceId);
               if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
               {
                    return RedirectToAction("Index", "Login");
               }

               CategoriesListData categoriesListData = new CategoriesListData { WorkspaceId = workspaceId };

               var categoriesDataResp = _session.CategoriesListAction(categoriesListData);

               TransactionItemData transactionItemData = new TransactionItemData { Id = id, WorkspaceId = workspaceId };

               var responseData = _session.TransactionItemAction(transactionItemData);
               responseData.Categories = categoriesDataResp.Categories;

               ViewBag.FormAction = "/Workspaces/" + workspaceId + "/Transactions/Update/" + id;

               return View(responseData);
          }

          [HttpPost]
          public ActionResult Update(int workspaceId, int id, TransactionsUpdateData data)
          {
               SessionStatus(workspaceId);
               if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
               {
                    return RedirectToAction("Index", "Login");
               }

               data.WorkspaceId = workspaceId;
               data.Id = id;

               var responseData = _session.TransactionsUpdateAction(data);

               return Redirect("/Workspaces/" + workspaceId + "/Transactions/Index");

          }

          [HttpDelete]
          public ActionResult Delete(int workspaceId, int id)
          {
               SessionStatus(workspaceId);
               if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
               {
                    return RedirectToAction("Index", "Login");
               }

               TransactionDeleteItemData transactionsDeleteData = new TransactionDeleteItemData { WorkspaceId = workspaceId, Id = id };

               var responseData = _session.TransactionDeleteItemAction(transactionsDeleteData);

               if (responseData.Status == false) return Json(new { success = true, message = responseData.StatusMsg });

               return Json(new { success = true });
          }
     }
}