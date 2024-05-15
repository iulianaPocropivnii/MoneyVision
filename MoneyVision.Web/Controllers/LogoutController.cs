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
          public ActionResult Index()
          {
               SessionStatus();

               var profile = System.Web.HttpContext.Current.GetMySessionObject();

               _session.UserLogoutAction(profile);

               return RedirectToAction("Index", "Login");
          }
     }

}

