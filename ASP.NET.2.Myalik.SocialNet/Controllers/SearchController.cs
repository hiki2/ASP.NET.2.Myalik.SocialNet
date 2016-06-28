using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.NET._2.Myalik.SocialNet.Mappers;
using ASP.NET._2.Myalik.SocialNet.Models;
using ASP.NET._2.Myalik.SocialNet.Utils.Collectors;
using BLL.Entities;
using BLL.Services.Interface;
using PagedList;

namespace ASP.NET._2.Myalik.SocialNet.Controllers
{
    [Authorize]
    public class SearchController : Controller
    {
        private readonly IUserService userService;
        private readonly IProfileService profileService;
        private readonly IService<CountryEntity> countryService; 

        public SearchController(IUserService userService, IProfileService profileService, IService<CountryEntity> countryService)
        {
            this.userService = userService;
            this.profileService = profileService;
            this.countryService = countryService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(countryService.GetALLEntities().Select(Mapper.ToView));
        }

        [HttpPost]
        public ActionResult SearchUsers(SeachViewModel searchModel)
        {
            var profiles = profileService.GetProfileEntitiesBySearchModel(Mapper.ToBll(searchModel)).Select(Mapper.ToView).ToList();
            return PartialView("SearchUsers", profiles);
        }

        [HttpPost]
        public ActionResult SearchAdminPanel(SeachViewModel searchModel)
        {
            var profiles = profileService.GetProfileEntitiesBySearchModel(Mapper.ToBll(searchModel));
            var userInformationCollector = new UserInformationCollector(userService, profileService);
            var userInfornation = profiles.Select(profile => userInformationCollector.UserInformationByProfileId(profile.id));
            return View("../Admin/Admin", userInfornation.ToPagedList(1,4));
        }


    }
}