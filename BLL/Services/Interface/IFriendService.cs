using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using BLL.Entities.Interface;

namespace BLL.Services.Interface
{
    public interface IFriendService : IService<FriendEntity>
    {
        void DeleteAddictionFriendEntities(int userId, int friendId);

        void CreateAddictionFriendEntities(int userId, int friendId);

        FriendEntity GetAdditionFriends(int userId, int friendId);

        IEnumerable<FriendEntity> GetAllUserFriendEntitiesByUserId(int userId);

        IEnumerable<FriendEntity> GetAllUserFriendEntitiesByProfileId(int profileId);

        IEnumerable<FriendEntity> GetAllUserFriendEntitiesByUserIdUsingConformation(int userId, bool confirmed);

        IEnumerable<FriendEntity> GetUserFriendEntitiesByUserIdAndNameUsingConformation(int userId, string name, bool confirmed);

        IEnumerable<FriendEntity> GetUserFriendEnByUserIdNameLastNameUsingConformation(int userId, string name, string lastName, bool confirmed);
    }
}
