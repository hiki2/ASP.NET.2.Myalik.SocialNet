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
    public class UserService : Service<UserEntity, DalUser>, IUserService
    {
        private readonly IUnitOfWork uow;
        public UserService(IUnitOfWork uow) : base(uow, uow.Users)
        {
            this.uow = uow;
        }

        public IEnumerable<UserEntity> GetTopUserEntities(int count)
        {
            return uow.Users.GetTopUsers(count).Select(Mapper.ToBll);
        }

        public IEnumerable<UserEntity> GetUserEntitiesByLastName(string lastName)
        {
            return uow.Users.GetUsersByLastName(lastName).Select(Mapper.ToBll);
        }

        public IEnumerable<UserEntity> GetUserEntitiesByName(string name)
        {
            return uow.Users.GetUsersByName(name).Select(Mapper.ToBll);
        }

        public IEnumerable<UserEntity> GetUserEntitiesByNameAndLastName(string name, string lastName)
        {
            return uow.Users.GetUsersByNameAndLastName(name, lastName).Select(Mapper.ToBll);
        }

        public IEnumerable<UserEntity> GetUserEntitiesByRoleName(string roleName)
        {
            return uow.Users.GetUsersByRoleName(roleName).Select(Mapper.ToBll);
        }

        public IEnumerable<UserEntity> GetUserEntitiesBySearchModel(SearchEntity search)
        {
            return uow.Users.GetUsersBySearchModel(Mapper.ToDal(search)).Select(Mapper.ToBll);
        }

        public UserEntity GetUserEntityByEmail(string email)
        {
            var user = uow.Users.GetUserByEmail(email);
            return user != null ? Mapper.ToBll(user) : null;
        }

        public UserEntity GetUserEntityByMobile(string mobile)
        {
            var user = uow.Users.GetUserByMobile(mobile);
            return user != null ? Mapper.ToBll(user) : null;
        }

        public UserEntity GetUserEntityByProfileId(int profileId)
        {
            var user = uow.Users.GetUserByProfileId(profileId);
            return user != null ? Mapper.ToBll(user) : null;
        }
    }
}
