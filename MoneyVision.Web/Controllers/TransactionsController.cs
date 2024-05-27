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

               return View(responseData);
          }
     }
}