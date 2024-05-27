using MoneyVision.Domain.Entities.Category.Requests;
using MoneyVision.Web.Extension;

using System.Web.Mvc;

namespace MoneyVision.Web.Controllers
{
    public class CategoriesController : BaseController
    {
        public ActionResult Index(int workspaceId)
        {
            SessionStatus(workspaceId);
            if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
            {
                return RedirectToAction("Index", "Dashboard");
            }

            CategoriesListData categoriesListData = new CategoriesListData { WorkspaceId = workspaceId };

            var responseData = _session.CategoriesListAction(categoriesListData);

            return View(responseData);
        }
    }
}