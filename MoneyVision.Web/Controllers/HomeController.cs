﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoneyVision.Web.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            SessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}