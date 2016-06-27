using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ASP.NET._2.Myalik.SocialNet.Filter.Filters.Filters;
using ASP.NET._2.Myalik.SocialNet.Models.Registration;
using ASP.NET._2.Myalik.SocialNet.Providers;
using BLL.Services.Interface;

namespace ASP.NET._2.Myalik.SocialNet.Controllers
{
    [MyExceptionFilter]
    public class AccountController : Controller
    {
        private readonly IProfileService profileService;
        public AccountController(IProfileService profileService)
        {
            this.profileService = profileService;
        }

        [HttpGet]
        public ActionResult Login()
        {
            var iden = HttpContext.User.Identity;
            if (iden.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
       //[ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.Email, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);
                    ViewBag.ProfileId = profileService.GetProfileEntityByUserEmail(model.Email).id;
                    return PartialView("Allright");
                }
                ModelState.AddModelError("", "Incorrect login or password.");
            }
            return PartialView(model);
        }

        [HttpGet]
        public ActionResult Register()
        {
            var iden = HttpContext.User.Identity;
            if (iden.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = ((SocialNetMembershipProvider) Membership.Provider).CreateUser(model);

                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, false);
                    return PartialView("Allright");
                }
                lModelState.AddModelError("", "Telephone or e-mail already in use.");
            }
            return PartialView(model);
        }

        [Authorize]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}