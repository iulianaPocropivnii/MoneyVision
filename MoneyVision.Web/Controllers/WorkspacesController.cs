using MoneyVision.Domain.Entities.Workspace.Requests;
using MoneyVision.Web.Extension;
using System.Web.Mvc;

namespace MoneyVision.Web.Controllers
{
    public class WorkspacesController : BaseController
    {

        // GET: Workspaces
        public ActionResult Index()
        {
               SessionStatus();
               if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
               {
                    return RedirectToAction("Index", "Dashboard");
               }

               var profile = System.Web.HttpContext.Current.GetMySessionObject();

               var workspaces = _session.WorkspacesListAction(new WorkspacesListData{ UserId = profile.Id});

               return View(workspaces);
        }
    }
}