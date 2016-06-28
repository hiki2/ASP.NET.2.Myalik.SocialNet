using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.NET._2.Myalik.SocialNet.Mappers;
using ASP.NET._2.Myalik.SocialNet.Models;
using ASP.NET._2.Myalik.SocialNet.Utils.Collectors;
using BLL.Services.Interface;
using PagedList;

namespace ASP.NET._2.Myalik.SocialNet.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly List<UserInformationViewModel> userInformations; 
        private readonly IUserService userService;
        private readonly IProfileService profileService;

        public AdminController(IUserService userService, IProfileService profileService)
        {
            this.userService = userService;
            this.profileService = profileService;
            userInformations = new UserInformationCollector(userService, profileService).AllUserInformation().ToList();
        }

        [HttpGet]
        public ActionResult Admin()
        {
            const int pageSize = 4;
            return View("Admin", userInformations.ToPagedList(1, pageSize));
        }

        [HttpGet]
        public ActionResult GetPage(int? page)
        {
            const int pageSize = 4;
            var pageNumber = page ?? 1;
            return PartialView("Admin", userInformations.ToPagedList(pageNumber,pageSize));
        }

        public ActionResult ConfigUser(int? page, UserInformationViewModel model)
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
                ViewBag.Message = model.Name + " " + model.LastName;
            }
            return GetPage(page);
        }
    }
}