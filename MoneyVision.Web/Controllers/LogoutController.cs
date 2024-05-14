using System;
using System.Web.Mvc;
using MoneyVision.BusinessLogic;
using MoneyVision.BusinessLogic.Interfaces;
using MoneyVision.Web.Extension;
using MoneyVision.Domain.Entities.User;
using MoneyVision.Domain.Entities.User.Requests;
using MoneyVision.Domain.Entities.User.Responses;

namespace MoneyVision.Web.Controllers
{
     public class LogoutController : BaseController
     {
          private readonly ISession _session;

          public LogoutController(ISession session)
          {
               _session = session;
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Index()
          {
               SessionStatus();

               var profile = System.Web.HttpContext.Current.GetMySessionObject();

               if (ModelState.IsValid)
               {
                    UProfileResp profileResp = _session.UserLogoutAction(profile);

                    if (profileResp != null)
                    {
                         if (profileResp.Status)
                         {
                              return RedirectToAction("Index", "Profile");
                         }
                         else
                         {
                              ModelState.AddModelError("", profileResp.StatusMsg);
                         }
                    }
                    else
                    {
                         ModelState.AddModelError("", "Eroare la deconectare. Vă rugăm să încercați din nou.");
                    }
               }

               return View();
          }
     }

}

