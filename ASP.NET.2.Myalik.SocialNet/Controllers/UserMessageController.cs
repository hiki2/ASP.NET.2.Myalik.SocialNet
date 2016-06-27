using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.NET._2.Myalik.SocialNet.Filter.Filters.Filters;
using ASP.NET._2.Myalik.SocialNet.Models;
using ASP.NET._2.Myalik.SocialNet.Utils.Collectors;
using BLL.Entities;
using BLL.Services.Interface;

namespace ASP.NET._2.Myalik.SocialNet.Controllers
{
    [MyExceptionFilter]
    public class UserMessageController : Controller
    {
        private readonly IUserService userService;
        private readonly IRoleService roleService;
        private readonly IProfileService profileService;
        private readonly IFriendService friendService;
        private readonly IUserMessageService userMessageService;
        private readonly IService<MessageEntity> messageService; 
        public UserMessageController(IUserService userService, IRoleService roleService, IProfileService profileService,
            IFriendService friendService, IUserMessageService userMessageService, IService<MessageEntity> messageService)
        {
            this.userService = userService;
            this.roleService = roleService;
            this.friendService = friendService;
            this.userMessageService = userMessageService;
            this.messageService = messageService;
            this.profileService = profileService;
        }

        public ActionResult SendMessage(int toProfileId, string message)
        {
            if (!ModelState.IsValid) return PartialView("SendMessage");
            if ((toProfileId == 0) || (toProfileId == (int) Profile["id"]) || (message == null) ||
                (message == string.Empty))
                return PartialView("SendMessage");
            var profile = profileService.GetEntity(toProfileId);
            var messageId = messageService.CreateEntity(new MessageEntity
            {
                MessageBody = message
            }).id;

            userMessageService.CreateEntity(new UserMessageEntity
            {
                IsRead = false,
                PostedDate = DateTime.Now,
                ToUserId = userService.GetUserEntityByProfileId(toProfileId).id,
                UserId = userService.GetUserEntityByProfileId((int) Profile["id"]).id,
                MessageId = messageId
            });
            return PartialView("MessageSended", new UserInformationViewModel
            {
                Name = profile.Name,
                LastName = profile.LastName
            });
        }

        public ActionResult UserMessages(int? profileId)
        {
            if (profileId == null)
                profileId = (int) Profile["id"];
            var messages =
                new UserMessageColletor(userService, profileService, userMessageService,messageService)
                .UserMessagesByProfileId((int)profileId);
            return View(messages);
        }
    }
}