﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO.Models;
using DAL.Interface;
using ORM.Models;
using System.Data.Entity;
using DAL.Mappers;
using ORM;

namespace DAL.Classes
{
    public class UserRepository : Repository<DalUser,User>, IUserRepository
    {
        private readonly SocialNetDB context;

        public UserRepository(SocialNetDB uow) : base(uow)
        {
            context = uow;
        }

        public IEnumerable<DalUser> GetTopUsers(int count)
        {
            return context.Users.OrderByDescending(u => u.id).Select(Mapper.ToDal).Take(count);
        }

        public DalUser GetUserByEmail(string email)
        {
            var retUser = context.Users.FirstOrDefault(user => user.Email == email);
            return retUser != null ? Mapper.ToDal(retUser) : null;
        }

        public DalUser GetUserByMobile(string mobile)
        {
            var retUser = context.Users.FirstOrDefault(user => user.Mobile == mobile);
            return retUser != null ? Mapper.ToDal(retUser) : null;
        }

        public DalUser GetUserByProfileId(int profileId)
        {
            var retUser = context.Users.FirstOrDefault(user => user.Profile.id == profileId);
            return retUser != null ? Mapper.ToDal(retUser) : null;
        }

        public IEnumerable<DalUser> GetUsersByLastName(string lastName)
        {
            return context.Users.Where(user => user.Profile.LastName == lastName).Select(user => Mapper.ToDal(user));   
        }

        public IEnumerable<DalUser> GetUsersByName(string name)
        {
            return context.Users.Where(user => user.Profile.Name == name).Select(user => Mapper.ToDal(user));
        }

        public IEnumerable<DalUser> GetUsersByNameAndLastName(string name, string lastName)
        {
            return context.Users.Where(user => (user.Profile.Name == name) && (user.Profile.LastName == lastName)).Select(user => Mapper.ToDal(user));
        }

        public IEnumerable<DalUser> GetUsersByRoleName(string roleName)
        {
            return context.Users.Where(user => user.Role.Name == roleName).Select(user => Mapper.ToDal(user));
        }

        public IEnumerable<DalUser> GetUsersBySearchModel(DalSearch search)
        {
            var fullName = search.NameAndSurName.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            return context.Users.Where(user =>
                (((fullName[0] == user.Profile.Name) && (fullName[1] == user.Profile.LastName))
                || ((fullName[0] == user.Profile.LastName) && (fullName[1] == user.Profile.Name)))
                && (search.Sex == user.Profile.Sex)
                && (search.Country == user.Profile.Country.Name)).Select(Mapper.ToDal);
        }
    }
}
