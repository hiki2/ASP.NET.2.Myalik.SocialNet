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
    public class SearchController : Controller
    {
        private readonly IUserService userService;
        private readonly IProfileService profileService;

        public SearchController(IUserService userService, IProfileService profileService)
        {
            this.userService = userService;
            this.profileService = profileService;
        }

        public ActionResult SearchUsers(SeachViewModel searchModel)
        {
            var profiles = profileService.GetProfileEntitiesBySearchModel(Mapper.ToBll(searchModel));
            return View(profiles);
        }

        public ActionResult SearchAdminPanel(SeachViewModel searchModel)
        {
            var profiles = profileService.GetProfileEntitiesBySearchModel(Mapper.ToBll(searchModel));
            var userInformationCollector = new UserInformationCollector(userService, profileService);
            var userInfornation = profiles.Select(profile => userInformationCollector.UserInformationByProfileId(profile.id));
            return View("../Admin/Admin", userInfornation);
        }
    }
}