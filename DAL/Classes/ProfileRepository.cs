﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO.Models;
using DAL.Interface;
using DAL.Mappers;
using ORM;
using ORM.Models;

namespace DAL.Classes
{
    public class ProfileRepository : Repository<DalProfile,Profile>, IProfileRepository
    {
        private readonly SocialNetDB context;

        public ProfileRepository(SocialNetDB uow) : base(uow)
        {
            context = uow;
        }

        public DalProfile GetProfileByUserEmail(string email)
        {
            var retUser = context.Users.FirstOrDefault(user => user.Email == email);
            if (retUser == null) return null;
            var retProfile = context.Profiles.FirstOrDefault(profile => retUser.ProfileId == profile.id);
            return retProfile != null ? Mapper.ToDal(retProfile) : null;
        }

        public DalProfile GetProfileByUserId(int userId)
        {
            var retUser = context.Users.FirstOrDefault(user => user.id == userId);
            if (retUser == null) return null;
            var retProfile = context.Profiles.FirstOrDefault(profile => retUser.ProfileId == profile.id);
            return retProfile != null ? Mapper.ToDal(retProfile) : null;
        }

        public DalProfile GetProfileByUserMobile(string mobile)
        {
            var retUser = context.Users.FirstOrDefault(user => user.Mobile == mobile);
            if (retUser == null) return null;
            var retProfile = context.Profiles.FirstOrDefault(profile => retUser.ProfileId == profile.id);
            return retProfile != null ? Mapper.ToDal(retProfile) : null;
        }

        public IEnumerable<DalProfile> GetProfilesByBirthDate(DateTime birthDate)
        {
            return context.Profiles.Where(profile => DateTime.Compare(profile.BirthDate, birthDate) == 0).Select(profile => Mapper.ToDal(profile));
        }

        public IEnumerable<DalProfile> GetProfilesByCountry(string countryName)
        {
            return context.Profiles.Where(profile => profile.Country.Name == countryName).Select(profile => Mapper.ToDal(profile));
        }

        public IEnumerable<DalProfile> GetProfilesBySearchModel(DalSearch search)
        {
            var fullName = search.NameAndSurName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return context.Profiles.Where(profile =>
                (((fullName[0] == profile.Name) && (fullName[1] == profile.LastName)) 
                || ((fullName[0] == profile.LastName) && (fullName[1] == profile.Name)))
                && (search.Sex == profile.Sex)
                && (search.Country == profile.Country.Name)).Select(Mapper.ToDal);
        }

        public IEnumerable<DalProfile> GetProfilesBySex(bool sex)
        {
            return context.Profiles.Where(profile => profile.Sex == sex).Select(profile => Mapper.ToDal(profile));
        }
         
    }
}
