﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoneyVision.Web.Controllers
{
     public class DashboardController : BaseController
     {
          public ActionResult Index(int workspaceId)
          {
               SessionStatus(workspaceId);
               if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
               {
                    return RedirectToAction("Index", "Login");
               }
               return View(workspaceId);
          }
     }
}