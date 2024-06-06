using MoneyVision.BusinessLogic;
using MoneyVision.Domain.Entities.Category.Requests;
using MoneyVision.Domain.Entities.Transaction.Requests;
using MoneyVision.Domain.Entities.User;
using MoneyVision.Domain.Entities.User.Responses;
using MoneyVision.Domain.Enums;
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

            ViewBag.FormAction = "/Workspaces/" + workspaceId + "/Categories/Index";
            ViewBag.workspaceId = workspaceId;
            return View(responseData);
        }

        [HttpPost]
        public ActionResult Index(int workspaceId, CategoryAddData data)
        {
            SessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
            {
                return Redirect("/Workspaces/" + workspaceId + "/Categories/Index");
            }

            data.WorkspaceId = workspaceId;
            var response = _session.AddCategoryAction(data);

            if (response.Status)
            {
                ViewBag.Message = "Category added successfully.";
            }
            else
            {
                ViewBag.Message = response.StatusMsg;
            }

            return Redirect("/Workspaces/" + workspaceId + "/Categories/Index");
        }

        [HttpPut]
        public JsonResult UpdateCategory(int workspaceId, int id, CategoryUpdateData data)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Validation failed" });
            }

            data.Id = id;
            data.WorkspaceId = workspaceId;

            var response = _session.CategoryUpdateAction(data);

            if (response.Status)
            {
                return Json(new { success = true, message = "Category updated successfully" });
            }
            else
            {
                return Json(new { success = false, message = response.StatusMsg });
            }
        }
    }

}



