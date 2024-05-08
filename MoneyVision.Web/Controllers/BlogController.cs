using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoneyVision.BusinessLogic.Core;
using MoneyVision.Domain.Enums;

namespace MoneyVision.Web.Controllers
{
     public class BlogController : BaseController
     {

          public ActionResult Index()
          {
               SessionStatus();
               if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login" )
               {
                    return RedirectToAction("Index", "Login");
               }
               if ((UserRole)System.Web.HttpContext.Current.Session["LoginLevel"] != UserRole.Admin)
               {
                    return RedirectToAction("Index", "Home");
               }
               return View();
          }
     } 
}