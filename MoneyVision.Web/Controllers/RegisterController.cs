using MoneyVision.BusinessLogic;
using MoneyVision.BusinessLogic.Interfaces;
using MoneyVision.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MoneyVision.Web.Models;


namespace MoneyVision.Web.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ISession _session;
        public RegisterController()
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
        public ActionResult Index(UserRegister register)
        {
            if (ModelState.IsValid)
            {
                URegisterData data = new URegisterData
                {
                    Credential = register.Credential,
                    Password = register.Password,
                    RegisterIp = Request.UserHostAddress,
                    RegisterDateTime = DateTime.Now
                };

               // var userRegister = _session.UserRegister(data);
                /*if (userLogin.Status)
                {
                     return RedirectToAction("Index", "Home");
                }
                else
                {
                     ModelState.AddModelError("", userLogin.StatusMsg);
                     return View();
                }*/
            }
            return RedirectToAction("Index", "Home");
        }
    }
}