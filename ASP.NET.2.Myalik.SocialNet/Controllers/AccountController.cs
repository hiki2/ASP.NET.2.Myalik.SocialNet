using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ASP.NET._2.Myalik.SocialNet.Filter.Filters.Filters;
using ASP.NET._2.Myalik.SocialNet.Models;
using ASP.NET._2.Myalik.SocialNet.Models.Registration;
using ASP.NET._2.Myalik.SocialNet.Providers;
using BLL.Services.Interface;

namespace ASP.NET._2.Myalik.SocialNet.Controllers
{
    [MyExceptionFilter]
    public class AccountController : Controller
    {
        private readonly IProfileService profileService;
        private readonly IUserService userService;
        public AccountController(IProfileService profileService, IUserService userService)
        {
            this.profileService = profileService;
            this.userService = userService;
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
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.Email, model.Password))
                {

                    if (((RoleViewModel) userService.GetUserEntityByEmail(model.Email).id).ToString("G") == "BannedUser")
                    {
                        ModelState.AddModelError("", "User is banned.");
                        return PartialView(model);
                    }
                    if (model.RememberMe)
                    {
                        const int timeout = 2880;
                        var ticket = new FormsAuthenticationTicket(model.Email, model.RememberMe, timeout);
                        var encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted)
                        {
                            Expires = DateTime.Now.AddMinutes(timeout),
                            HttpOnly = true
                        };
                        HttpContext.Response.Cookies.Add(cookie);
                    }
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
        [ValidateAntiForgeryToken]
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
                ModelState.AddModelError("", "Telephone or e-mail already in use.");
            }
            return PartialView(model);
        }

        [Authorize]
        public ActionResult LogOff()
        {
            if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
            {
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName)
                {
                    Expires = DateTime.Now.AddDays(-1d)
                };
                Response.Cookies.Add(cookie);
            }
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}