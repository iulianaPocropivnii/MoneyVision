using MoneyVision.BusinessLogic;
using MoneyVision.Domain.Entities.User;
using MoneyVision.Domain.Entities.User.Responses;
using MoneyVision.Domain.Entities.User.Requests;
using MoneyVision.Domain.Enums;
using MoneyVision.Web.Extension;
using System.Web.Mvc;

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
          public ActionResult Index()
          {
               SessionStatus();

               if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
               {
                    return RedirectToAction("Index", "Login");
               }

               var profile = System.Web.HttpContext.Current.GetMySessionObject();

               return View(profile);
          }

          [HttpPost]
          public ActionResult AddUserToWorkspace(UAddData data)
          {
               SessionStatus();
               if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
               {
                    return RedirectToAction("Index", "Login");
               }

               var response = sessionBL.AddUserAction(data);

               if (response.Status)
               {
                    ViewBag.Message = "User added to the workspace successfully.";
               }
               else
               {
                    ViewBag.Message = response.StatusMsg;
               }

               return View();
          }
     }
}
