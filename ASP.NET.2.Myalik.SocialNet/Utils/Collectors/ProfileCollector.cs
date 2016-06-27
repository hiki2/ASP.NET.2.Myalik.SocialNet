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
    public class ProfileCollector
    {
        private readonly IProfileService profileService;
        private readonly IService<CountryEntity> countryService;

        public ProfileCollector(IProfileService profileService, IService<CountryEntity> countryService)
        {
            this.profileService = profileService;
            this.countryService = countryService;
        }

        public ProfileViewModel ProfileModelWithCountry(int profileId)
        {
            var profile = profileService.GetEntity(profileId);
            var profileViewModel = Mapper.ToView(profile);
            profileViewModel.Country = profile.CountryId != null
                ? countryService.GetEntity((int)profile.CountryId).Name
                : null;
            return profileViewModel;
        }
    }
}