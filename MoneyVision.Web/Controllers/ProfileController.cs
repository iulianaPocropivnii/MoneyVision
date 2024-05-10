using MoneyVision.BusinessLogic;
using MoneyVision.BusinessLogic.Interfaces;
using MoneyVision.Domain.Entities.User.Requests;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MoneyVision.Web.Models;
using MoneyVision.Domain.Entities.User.Responses;
using System.Diagnostics;
using System.Web.UI.WebControls;
using System.Web;
using System.Threading.Tasks;
using MoneyVision.Web.Extension;

namespace MoneyVision.Web.Controllers
{
     public class ProfileController : BaseController
     {
          private readonly ISession _session;

          public ProfileController()
          {
               var bl = new BussinesLogic();
               _session = bl.GetSessionBL();
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
          [ValidateAntiForgeryToken]
          public ActionResult Index(UProfileData userProfileData)
          {
               SessionStatus();

               if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
               {
                    return RedirectToAction("Index", "Login");
               }

               var profile = System.Web.HttpContext.Current.GetMySessionObject();

               if (ModelState.IsValid)
               {
                    UProfileResp profileResp = _session.UserProfileAction(userProfileData, profile);

                    if (profileResp.Status)
                    {
                         ViewBag.SuccessMessage = "Profilul a fost actualizat cu succes.";
                         return RedirectToAction("Index", "Profile");}
                    else
                    {
                         ModelState.AddModelError("", profileResp.StatusMsg);
                    }
               }

               return View(profile);
          }
     }
}