using MoneyVision.BusinessLogic;
using MoneyVision.BusinessLogic.Interfaces;
using MoneyVision.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MoneyVision.Web.Models;
using MoneyVision.Domain.Entities.User.Responses;
using System.Diagnostics;


namespace MoneyVision.Web.Controllers
{
     public class LoginController : Controller
     {
          private readonly ISession _session;
          public LoginController()
          {
               var bl = new BussinesLogic();
               _session = bl.GetSessionBL();
          }

          public ActionResult Index()
          {
               return View();
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Index(UserLogin login)
          {
               Debug.WriteLine("logare succesiful");
               Debug.WriteLine(login);
               if (ModelState.IsValid)
               {
                    ULoginData data = new ULoginData
                    {
                         Credential = login.Credential,
                         Password = login.Password,
                         LoginIp = Request.UserHostAddress,
                         LoginDateTime = DateTime.Now
                    };

                    Debug.WriteLine("nush");
                    Debug.WriteLine(login.Credential);
                    Debug.WriteLine(login.Password);
                    ULoginResp userResp = _session.UserLoginAction(data);
                    ViewBag.LogSuccess = userResp.Status;
                    if (userResp.Status)
                    {
                         return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                         ModelState.AddModelError("", userResp.StatusMsg);
                         return View();
                    }
               }
               return RedirectToAction("Index", "Home");
          }
     }
}