using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO.Models;
using DAL.Interface;
using DAL.Mappers;
using ORM.Models;
using ORM;

namespace DAL.Classes
{
    public class FriendRepository : Repository<DalFriend, Friend>, IFriendRepository
    {
        private readonly SocialNetDB context;
        public FriendRepository(SocialNetDB uow) : base(uow)
        {
            context = uow;
        }

        public void DeleteAddictionFriends(int userId, int friendId)
        {
            var ormEntities = context.Friends.Where(friend =>
                    ((friend.UserId == userId)
                    && (friend.FriendId == friendId))
                    || ((friend.UserId == friendId)
                    && (friend.FriendId == userId)));
            context.Friends.RemoveRange(ormEntities);
        }

        public DalFriend GetAdditionFriends(int userId, int friendId)
        {
            var retFriend =
                context.Friends.FirstOrDefault(
                    friend =>
                        ((friend.UserId == userId) && (friend.FriendId == friendId)) ||
                        ((friend.FriendId == userId) && (friend.UserId == friendId)));
            return retFriend != null ? Mapper.ToDal(retFriend) : null;
        }

        public IEnumerable<DalFriend> GetAllUserFriendsByProfileId(int profileId)
        {
            return context.Friends.Where(friend => (friend.User.Profile.id == profileId) || (friend.UserFriend.Profile.id == profileId)).Select(Mapper.ToDal);
        }

        public IEnumerable<DalFriend> GetAllUserFriendsByUserId(int userId)
        {
            return context.Friends.Where(friend => (friend.UserId == userId)||(friend.FriendId == userId)).Select(Mapper.ToDal);
        }
       
        public IEnumerable<DalFriend> GetAllUserFriendsByUserIdUsingConformation(int userId, bool confirmed)
        {
            return context.Friends.Where(friend => (friend.UserId == userId) && (friend.Confirmed == confirmed)).Select(Mapper.ToDal);
        }

        public IEnumerable<DalFriend> GetUserFriendsByUserIdAndNameUsingConformation(int userId, string name, bool confirmed)
        {
            return context.Friends.Where(friend => ((friend.UserId == userId) || (friend.FriendId == userId))
            && (friend.UserFriend.Profile.Name == name) 
            && (friend.Confirmed == confirmed))
            .Select(Mapper.ToDal);
        }

        public IEnumerable<DalFriend> GetUserFriendsByUserIdNameLastNameUsingConformation(int userId, string name, string lastName, bool confirmed)
        {
            return context.Friends
                .Where(friend => ((friend.UserId == userId) || (friend.FriendId == userId))
                && (friend.Confirmed == confirmed) 
                && (friend.UserFriend.Profile.Name == name) 
                && (friend.UserFriend.Profile.LastName == lastName))
                .Select(Mapper.ToDal);
        }

        
    }
}
