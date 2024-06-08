using MoneyVision.BusinessLogic;
using MoneyVision.Domain.Entities.User;
using MoneyVision.Domain.Entities.User.Responses;
using MoneyVision.Domain.Entities.User.Requests;
using MoneyVision.Domain.Enums;
using MoneyVision.Web.Extension;
using System.Collections.Generic;
using System.Web.Mvc;
using MoneyVision.Domain.Entities.Transaction.Requests;

namespace MoneyVision.Web.Controllers
{
     public class UsersController : BaseController
     {
          private readonly SessionBL sessionBL;

          public UsersController()
          {
               this.sessionBL = new SessionBL();
          }

          [HttpGet]
          public ActionResult Index(int workspaceId)
          {
               SessionStatus();

               if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
               {
                    return RedirectToAction("Index", "Login");
               }

               var profile = System.Web.HttpContext.Current.GetMySessionObject();
               var data = new UListData { WorkspaceId = workspaceId, UserId = profile.Id};
               var response = sessionBL.UsersListAction(data);

               ViewBag.WorkspaceId = workspaceId;
               ViewBag.FormAction = "/Workspaces/" + workspaceId + "/Users/Index";
               return View(response);
          }

          [HttpPost]
          public ActionResult Index(int workspaceId, UAddData data)
          {
               SessionStatus();
               if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
               {
                    return Redirect("/Workspaces/" + workspaceId + "/Users/Index");
               }

               data.Role = UserRole.Viewer;
               data.WorkspaceId = workspaceId;

               var response = sessionBL.AddUserAction(data);

               if (response.Status)
               {
                    ViewBag.Message = "User added to the workspace successfully.";
               }
               else
               {
                    ViewBag.Message = response.StatusMsg;
               }

               return Redirect("/Workspaces/" + workspaceId + "/Users/Index");
          }

          [HttpPost]
          public ActionResult Delete(int workspaceId, int id)
          {
               SessionStatus(workspaceId);
               if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
               {
                    return RedirectToAction("Index", "Login");
               }

               UDeleteData uDeleteData = new UDeleteData { WorkspaceId = workspaceId, UserId = id };

               var responseData = _session.UserDeleteAction(uDeleteData);

               if (responseData.Status == false)
               {
                    return Json(new { success = false, message = responseData.StatusMsg });
               }
               else
               {
                    return Json(new { success = true });
               }
          }

          [HttpPost]
          public ActionResult Update(int workspaceId, int id, UChangeRoleData data)
          {
               SessionStatus(workspaceId);
               if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
               {
                    return RedirectToAction("Index", "Login");
               }

               data.WorkspaceId = workspaceId;
               data.UserId = id;

               var responseData = _session.UserChangeRoleAction(data);

               if (responseData.Status == false)
               {
                    return Json(new { success = false, message = responseData.StatusMsg });
               }
               else
               {
                    return Json(new { success = true });
               }
          }
     }
}
