using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP.NET._2.Myalik.SocialNet.Mappers;
using ASP.NET._2.Myalik.SocialNet.Models;
using BLL.Services.Interface;

namespace ASP.NET._2.Myalik.SocialNet.Utils.Collectors
{
    public class UserInformationCollector
    {
        private readonly IProfileService profileService;
        private readonly IUserService userService;

        public UserInformationCollector(IUserService userService, IProfileService profileService)
        {
            this.userService = userService;
            this.profileService = profileService;
        }

        public IEnumerable<UserInformationViewModel> UserInformationTop(int count)
        {
            var users = userService.GetTopUserEntities(count);
            return from user in users
                let profile = profileService.GetProfileEntityByUserId(user.id)
                select Create(Mapper.ToView(profile), Mapper.ToView(user));
        }

        public UserInformationViewModel UserInformationByProfileId(int profileId)
        {
            return Create(Mapper.ToView(profileService.GetEntity(profileId)),
                Mapper.ToView(userService.GetUserEntityByProfileId(profileId)));
        }

        public UserInformationViewModel UserInformationByUserId(int userId)
        {
            return Create(Mapper.ToView(profileService.GetProfileEntityByUserId(userId)),
                Mapper.ToView(userService.GetEntity(userId)));
        }

        private UserInformationViewModel Create(ProfileViewModel profile, UserViewModel user)
        {
            return new UserInformationViewModel
            {
                UserId = user.id,
                Email = user.Email,
                LastName = profile.LastName,
                Mobile = user.Mobile,
                Name = profile.Name,
                Role = user.Role
            };
        }
    }
}