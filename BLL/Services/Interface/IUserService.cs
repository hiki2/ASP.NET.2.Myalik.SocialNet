using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using BLL.Entities.Interface;

namespace BLL.Services.Interface
{
    public interface IUserService : IService<UserEntity>
    {
        UserEntity GetUserEntityByMobile(string mobile);

        UserEntity GetUserEntityByEmail(string email);

        UserEntity GetUserEntityByProfileId(int profileId);

        IEnumerable<UserEntity> GetUserEntitiesByName(string name);

        IEnumerable<UserEntity> GetUserEntitiesByLastName(string lastName);

        IEnumerable<UserEntity> GetUserEntitiesByRoleName(string roleName);

        IEnumerable<UserEntity> GetUserEntitiesByNameAndLastName(string name, string lastName);

        IEnumerable<UserEntity> GetTopUserEntities(int count);

        IEnumerable<UserEntity> GetUserEntitiesBySearchModel(SearchEntity search);

    }
}
