using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP.NET._2.Myalik.SocialNet.Mappers;
using ASP.NET._2.Myalik.SocialNet.Models;
using BLL.Entities;
using BLL.Services.Interface;

namespace ASP.NET._2.Myalik.SocialNet.Utils.Collectors
{
    public class UserMessageColletor
    {
        private readonly IUserService userService;
        private readonly IProfileService profileService;
        private readonly IUserMessageService userMessageService;
        private readonly IService<MessageEntity> messageService;
        
        public UserMessageColletor(IUserService userService,IProfileService profileService, IUserMessageService userMessageService,
            IService<MessageEntity> messageService)
        {
            this.profileService = profileService;
            this.userMessageService = userMessageService;
            this.messageService = messageService;
            this.userService = userService;
        }

        public IEnumerable<UserMessageViewModel> UserMessagesByProfileId(int profileId)
        {
            var userId = userService.GetUserEntityByProfileId(profileId).id;
            return UserMessagesByUserId(userId);
        }

        public IEnumerable<UserMessageViewModel> UserMessagesByUserId(int userId)
        {
            return
                userMessageService.GetAllUserMessageEntitiesByUserId(userId)
                    .Select(message => new UserMessageViewModel
                    {
                        IsRead = message.IsRead,
                        Message = messageService.GetEntity(message.MessageId).MessageBody,
                        PostedDate = message.PostedDate,
                        Profile = Mapper.ToView(profileService.GetProfileEntityByUserId(message.UserId == userId
                            ? message.UserId
                            : message.ToUserId)),
                        Sended = userId == message.UserId
                    });
        }
    }
}