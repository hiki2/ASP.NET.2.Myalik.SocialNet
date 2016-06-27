using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP.NET._2.Myalik.SocialNet.Mappers;
using ASP.NET._2.Myalik.SocialNet.Models;
using BLL.Services.Interface;
using BLL.Entities;

namespace ASP.NET._2.Myalik.SocialNet.Utils.Collectors
{
    public class MessageWallCollector
    {
        private readonly IProfileService profileService;
        private readonly IMessageWallService messageWallService;
        private readonly IService<MessageEntity> messageService;

        public MessageWallCollector(IProfileService profileService, IMessageWallService messageWallService, IService<MessageEntity> messageService)
        {
            this.profileService = profileService;
            this.messageWallService = messageWallService;
            this.messageService = messageService;
        }

        public IEnumerable<MessageWallViewModel> MessageWallByProfileId(int profileId)
        {
            var messageWall = messageWallService.GetAllWallMessageEntitiesByProfileId(profileId).ToList();
            var messageWallViewModels = messageWall.Select(entity => new MessageWallViewModel
            {
                id = entity.id,
                Message = Mapper.ToView(messageService.GetEntity(entity.MessageId)),
                PostedUser = Mapper.ToView(profileService.GetProfileEntityByUserId(entity.PostedUserId)),
                PosteDate = entity.PostedDate
            });
            return messageWallViewModels;
        }
    }
}