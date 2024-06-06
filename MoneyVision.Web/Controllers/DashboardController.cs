using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;
using System.Web.Mvc;
using MoneyVision.Helpers;

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

               var st = "WTDWRmCthKLpb"; // that's not secret, so it is okay

               var sumboardSecret = Environment.GetEnvironmentVariable("Sumboard");

               var token = JwtTokenGenerator.GenerateToken(st, workspaceId, sumboardSecret);

               ViewBag.token = token;

               return View(workspaceId);
          }
     }
}