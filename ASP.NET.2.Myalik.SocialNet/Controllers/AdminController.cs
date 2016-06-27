using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.NET._2.Myalik.SocialNet.Mappers;
using ASP.NET._2.Myalik.SocialNet.Models;
using ASP.NET._2.Myalik.SocialNet.Utils.Collectors;
using BLL.Services.Interface;

namespace ASP.NET._2.Myalik.SocialNet.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IUserService userService;
        private readonly IProfileService profileService;

        public AdminController(IUserService userService, IProfileService profileService)
        {
            this.userService = userService;
            this.profileService = profileService;
        }

        [HttpPost]
        public ActionResult Admin(int? count)
        {
            if (count == null)
                count = 5;
            return PartialView("Admin", new UserInformationCollector(userService, profileService).UserInformationTop((int)count));
        }

        [HttpGet]
        public ActionResult Admin()
        {
            return View("Admin", new UserInformationCollector(userService, profileService).UserInformationTop(5));
        }

        public ActionResult ConfigUser(int? count, UserInformationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = userService.GetEntity(model.UserId);
                var profile = profileService.GetProfileEntityByUserId(model.UserId);
                user.Email = model.Email;
                user.Mobile = model.Mobile;
                user.RoleId = (int) model.Role;
                userService.UpdateEntity(user);
                profile.Name = model.Name;
                profile.LastName = model.LastName;
                profileService.UpdateEntity(profile);
                ViewBag.Message = model.Name + " " +model.LastName;
            }
            return Admin(5);
        }
    }
}