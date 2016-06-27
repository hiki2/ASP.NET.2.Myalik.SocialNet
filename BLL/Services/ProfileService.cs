using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using BLL.Services.Interface;
using DAL.DTO.Models;
using DAL.Interface;
using BLL.Mappers;

namespace BLL.Services
{
    public class ProfileService : Service<ProfileEntity, DalProfile>, IProfileService
    {
        private readonly IUnitOfWork uow;
        public ProfileService(IUnitOfWork uow) : base(uow, uow.Profiles)
        {
            this.uow = uow;
        }

        public IEnumerable<ProfileEntity> GetProfileEntitiesByBirthDate(DateTime birthDate)
        {
            return uow.Profiles.GetProfilesByBirthDate(birthDate).Select(Mapper.ToBll);
        }

        public IEnumerable<ProfileEntity> GetProfileEntitiesByCountry(string countryName)
        {
            return uow.Profiles.GetProfilesByCountry(countryName).Select(Mapper.ToBll);
        }

        public IEnumerable<ProfileEntity> GetProfileEntitiesBySearchModel(SearchEntity search)
        {
            return uow.Profiles.GetProfilesBySearchModel(Mapper.ToDal(search)).Select(Mapper.ToBll);
        }

        public IEnumerable<ProfileEntity> GetProfileEntitiesBySex(bool sex)
        {
            return uow.Profiles.GetProfilesBySex(sex).Select(Mapper.ToBll);
        }

        public ProfileEntity GetProfileEntityByUserEmail(string email)
        {
            var profile = uow.Profiles.GetProfileByUserEmail(email);
            return profile != null ? Mapper.ToBll(profile) : null;
        }

        public ProfileEntity GetProfileEntityByUserId(int userId)
        {
            var profile = uow.Profiles.GetProfileByUserId(userId);
            return profile != null ? Mapper.ToBll(profile) : null;
        }

        public ProfileEntity GetProfileEntityByUserMobile(string mobile)
        {
            var profile = uow.Profiles.GetProfileByUserMobile(mobile);
            return profile != null ? Mapper.ToBll(profile) : null;
        }
    }
}
