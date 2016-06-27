using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Profile;
using ASP.NET._2.Myalik.SocialNet.Filter.Filters.Filters;
using ASP.NET._2.Myalik.SocialNet.Models;
using BLL.Services.Interface;
using ASP.NET._2.Myalik.SocialNet.Mappers;
using ASP.NET._2.Myalik.SocialNet.Utils.Collectors;
using BLL.Entities;

namespace ASP.NET._2.Myalik.SocialNet.Controllers
{
    [Authorize]
    [MyExceptionFilter]
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IRoleService roleService;
        private readonly IProfileService profileService;
        private readonly IFriendService friendService;
        private readonly IMessageWallService messageWallService;
        private readonly IService<MessageEntity> messageService;
        public UserController(IUserService userService, IRoleService roleService, IProfileService profileService, 
            IFriendService friendService, IMessageWallService messageWallService, IService<MessageEntity> messageService)
        {
            this.userService = userService;
            this.roleService = roleService;
            this.profileService = profileService;
            this.friendService = friendService;
            this.messageWallService = messageWallService;
            this.messageService = messageService;
        }

        [HttpGet]     
        public ActionResult EditProfileInformation()
        {
            return View(Mapper.ToView(profileService.GetProfileEntityByUserEmail(User.Identity.Name)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfileInformation(ProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                Profile["About"] = model.About;
                Profile["Activity"] = model.Activity;
                Profile["Interests"] = model.Interests;
                Profile["FavoriteMusic"] = model.FavoriteMusic;
                Profile["FavoriteFilms"] = model.FavoriteFilms;
                return RedirectToAction("Index","Home");
            }
            return PartialView();
        }
        
        [HttpGet]
        public ActionResult FriendsList(int? profileId)
        {
            if (profileId == null)
                profileId = (int)Profile["id"];
            var friends =
                new FriendsCollector(userService, profileService, friendService).ProfileFriends((int)profileId);
            ViewData["ProfileId"] = profileId;
            return View(friends);
        }

        [HttpPost]
        public ActionResult AvatarUpload(HttpPostedFileBase file)
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Index", "Home");
            if (file == null) return RedirectToAction("Index", "Home");
            byte[] fileData;
            using (var binaryReader = new BinaryReader(file.InputStream))
            {
                fileData = binaryReader.ReadBytes(file.ContentLength);
            }
            Profile["Avatar"] = fileData;
            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public ActionResult AddDeleteFriend(string friendId, string action)
        {
            int parsedFriendId;
            if (!int.TryParse(friendId, out parsedFriendId))
                return RedirectToAction("Index", "Home", new {profileId = parsedFriendId});
            var friendUserId = userService.GetUserEntityByProfileId(parsedFriendId).id;
            var currentUserId = userService.GetUserEntityByProfileId((int)Profile["id"]).id;

            if (action == "delete")
            {
                friendService.DeleteAddictionFriendEntities(currentUserId, friendUserId);
            }
            else
            {
                friendService.CreateAddictionFriendEntities(currentUserId, friendUserId);
            }
            return RedirectToAction("Index", "Home", new { profileId = parsedFriendId });
        }

        [HttpPost]
        public ActionResult AddWallMessage(string profileId, string message)
        {
            int parsedProfileId;
            if (!int.TryParse(profileId, out parsedProfileId))
                return RedirectToAction("Index", "Home", new { profileId = parsedProfileId });
            messageWallService.CreateEntity(new MessageWallEntity
            {
                PostedDate = DateTime.Now,
                PostedUserId = userService.GetUserEntityByProfileId((int)Profile["id"]).id,
                MessageId = messageService.CreateEntity(new MessageEntity
                {
                    MessageBody = message,
                }).id,
                ProfileId = parsedProfileId
            });
            ViewData["ProfileId"] = parsedProfileId;
            return PartialView("../Home/Wall",
                new MessageWallCollector(profileService, messageWallService, messageService).MessageWallByProfileId(
                    parsedProfileId));
        }

        [HttpPost]
        public ActionResult ConfirmFriend(int friendId)
        {
            AddDeleteFriend(friendId.ToString(), "add");
            var friends =
                new FriendsCollector(userService, profileService, friendService).ProfileFriends((int)Profile["id"]);
            return PartialView("FriendsList", friends);
        }

        [HttpPost]
        public ActionResult DeleteRequestFriend(int friendId)
        {
            AddDeleteFriend(friendId.ToString(), "delete");
            var friends =
                new FriendsCollector(userService, profileService, friendService).ProfileFriends((int)Profile["id"]);
            return PartialView("FriendsList", friends);
        }

        [HttpPost]
        public ActionResult DeleteFriend(int friendId)
        {
            AddDeleteFriend(friendId.ToString(), "delete");
            var friends =
                new FriendsCollector(userService, profileService, friendService).ProfileFriends((int) Profile["id"]);
            ViewData["ProfileId"] = (int)Profile["id"];
            return PartialView("FriendsList", friends);
        }
    }
}