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
    public class FriendsCollector
    {
        private readonly IProfileService profileService;
        private readonly IFriendService friendService;
        private readonly IUserService userService;
        public FriendsCollector(IUserService userService, IProfileService profileService, IFriendService friendService)
        {
            this.profileService = profileService;
            this.friendService = friendService;
            this.userService = userService;
        }

        public IEnumerable<FriendViewModel> UserFriends(int userId)
        {
            var friendViewModels = friendService.GetAllUserFriendEntitiesByUserId(userId).Select(entity => Create(entity, userId)).ToList();
            return friendViewModels;
        }

        public IEnumerable<FriendViewModel> ProfileFriends(int profileId)
        {
            var userId = userService.GetUserEntityByProfileId(profileId).id;
            return UserFriends(userId);           
        }

        private FriendViewModel Create(FriendEntity entity, int userId)
        {
            return new FriendViewModel
            {
                id = entity.id,
                ConfirmDate = entity.ConfirmDate,
                Confirmed = entity.Confirmed,
                RequestDate = entity.RequestDate,
                Profile =
                    Mapper.ToView(
                        profileService.GetProfileEntityByUserId(entity.FriendId == userId
                            ? entity.UserId
                            : entity.FriendId)),

                IsRequest = entity.FriendId != userId
            };
        }
    }
}