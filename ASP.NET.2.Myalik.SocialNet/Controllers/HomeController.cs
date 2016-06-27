using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ASP.NET._2.Myalik.SocialNet.Filter.Filters.Filters;
using ASP.NET._2.Myalik.SocialNet.Models.Registration;
using BLL.Services.Interface;
using ASP.NET._2.Myalik.SocialNet.Mappers;
using ASP.NET._2.Myalik.SocialNet.Models;
using ASP.NET._2.Myalik.SocialNet.Utils.Collectors;
using BLL.Entities;

namespace ASP.NET._2.Myalik.SocialNet.Controllers
{
    [Authorize]
    [MyExceptionFilter]
    public class HomeController : Controller
    {
        private readonly IUserService userService;
        private readonly IProfileService profileService;
        private readonly IService<CountryEntity> countryService;
        private readonly IFriendService friendService;
        private readonly IMessageWallService messageWallService;
        private readonly IService<MessageEntity> messageService;

        public HomeController(IUserService userService,IProfileService profileService,
            IService<CountryEntity> countryService,
            IFriendService friendService, IMessageWallService messageWallService, IService<MessageEntity> messageService)
        {
            this.userService = userService;
            this.profileService = profileService;
            this.countryService = countryService;
            this.friendService = friendService;
            this.messageWallService = messageWallService;
            this.messageService = messageService;
        }

        public ActionResult Index(int? profileId)
        {
            if (profileId == null)
                profileId = (int)Profile["id"];
            var user = userService.GetUserEntityByProfileId((int)profileId);
            if (user == null)
                return RedirectToAction("Index", "Error");       
            ViewData["ProfileId"] = profileId;
            return
                View(new PageViewModel
                {
                    Friends = new FriendsCollector(userService,profileService,friendService).UserFriends(user.id),
                    MessageWall = new MessageWallCollector(profileService,messageWallService,messageService).MessageWallByProfileId((int)profileId),
                    Profile =  new ProfileCollector(profileService, countryService).ProfileModelWithCountry((int)profileId),
                    User = Mapper.ToView(user),
                });
        }

    }
}