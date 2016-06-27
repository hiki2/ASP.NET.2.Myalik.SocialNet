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
    public class FriendService : Service<FriendEntity, DalFriend>, IFriendService
    {
        private readonly IUnitOfWork uow;

        public FriendService(IUnitOfWork uow) : base(uow, uow.Friends)
        {
            this.uow = uow;
        }

        public IEnumerable<FriendEntity> GetAllUserFriendEntitiesByUserId(int userId)
        {
            return uow.Friends.GetAllUserFriendsByUserId(userId).Select(Mapper.ToBll);
        }

        public IEnumerable<FriendEntity> GetAllUserFriendEntitiesByProfileId(int profileId)
        {
            return uow.Friends.GetAllUserFriendsByProfileId(profileId).Select(Mapper.ToBll);
        }

        public IEnumerable<FriendEntity> GetAllUserFriendEntitiesByUserIdUsingConformation(int userId, bool confirmed)
        {
            return uow.Friends.GetAllUserFriendsByUserIdUsingConformation(userId, confirmed).Select(Mapper.ToBll);
        }

        public IEnumerable<FriendEntity> GetUserFriendEnByUserIdNameLastNameUsingConformation(int userId, string name,
            string lastName, bool confirmed)
        {
            return
                uow.Friends.GetUserFriendsByUserIdNameLastNameUsingConformation(userId, name, lastName, confirmed)
                    .Select(Mapper.ToBll);
        }

        public IEnumerable<FriendEntity> GetUserFriendEntitiesByUserIdAndNameUsingConformation(int userId, string name,
            bool confirmed)
        {
            return
                uow.Friends.GetUserFriendsByUserIdAndNameUsingConformation(userId, name, confirmed).Select(Mapper.ToBll);
        }

        public void DeleteAddictionFriendEntities(int userId, int friendId)
        {
            uow.Friends.DeleteAddictionFriends(userId, friendId);
            uow.Commit();
        }

        public void CreateAddictionFriendEntities(int userId, int friendId)
        {
            var entity = GetAdditionFriends(userId, friendId);
            if (entity == null)
            {
                uow.Friends.Create(new DalFriend
                {
                    Confirmed = false,
                    FriendId = friendId,
                    UserId = userId,
                    RequestDate = DateTime.Now,
                });
            }
            else if (entity.UserId != userId)
            {
                entity.Confirmed = true;
                entity.ConfirmDate = DateTime.Now;
                uow.Friends.Update(Mapper.ToDal(entity));
            }
            uow.Commit();
        }


        public FriendEntity GetAdditionFriends(int userId, int friendId)
        {
            var friend = uow.Friends.GetAdditionFriends(userId, friendId);
            return friend != null ? Mapper.ToBll(friend) : null;
        }
    }
}
