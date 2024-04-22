﻿using MoneyVision.BusinessLogic;
using MoneyVision.BusinessLogic.Interfaces;
using MoneyVision.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MoneyVision.Web.Models;
using MoneyVision.Domain.Entities.User.Responses;
using System.Diagnostics;
using System.Web.UI.WebControls;
using System.Web;


namespace MoneyVision.Web.Controllers
{
     public class LoginController : BaseController
     {
          private readonly ISession _session;
          public LoginController()
          {
               var bl = new BussinesLogic();
               _session = bl.GetSessionBL();
          }

          public ActionResult Index()
          {
            SessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] == "login")
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Index(UserLogin login)
          {
               Debug.WriteLine("logare succesful");
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

                    ULoginResp userResp = _session.UserLoginAction(data);
                if (userResp.Status)
                    {
                    HttpCookie cookie = _session.GenCookie(login.Credential);
                    ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                    return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                         ModelState.AddModelError("", userResp.StatusMsg);
                         return View();
                    }
               }
            return View();


        }
     }
}