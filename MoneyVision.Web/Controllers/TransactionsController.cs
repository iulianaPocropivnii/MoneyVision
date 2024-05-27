using MoneyVision.Domain.Entities.Category.Requests;
using MoneyVision.Domain.Entities.Transaction.Requests;
using MoneyVision.Web.Extension;

using System.Web.Mvc;

namespace MoneyVision.Web.Controllers
{
     public class TransactionsController : BaseController
     {
          // GET: Transactions
          public ActionResult Index(int workspaceId)
          {
               SessionStatus(workspaceId);
               if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
               {
                    return RedirectToAction("Index", "Dashboard");
               }

               TransactionsListData transactionsListData = new TransactionsListData { WorkspaceId = workspaceId };

               var responseData = _session.TransactionsListAction(transactionsListData);

               ViewBag.CreateUrl = "/Workspaces/" + workspaceId + "/Transactions/Create";

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
     }
}