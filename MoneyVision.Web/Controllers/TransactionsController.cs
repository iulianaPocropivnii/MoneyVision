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

               var profile = System.Web.HttpContext.Current.GetMySessionObject();

               TransactionsListData transactionsListData = new TransactionsListData { WorkspaceId = profile.WorkspaceId };

               var responseData = _session.TransactionsListAction(transactionsListData);

               return View(responseData);
          }
     }
}