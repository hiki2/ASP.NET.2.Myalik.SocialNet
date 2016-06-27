using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO.Models;

namespace DAL.Interface
{
    public interface IFriendRepository : IRepository<DalFriend>
    {
        void DeleteAddictionFriends(int userId, int friendId);

        DalFriend GetAdditionFriends(int userId, int friendId);

        IEnumerable<DalFriend> GetAllUserFriendsByUserId(int userId);

        IEnumerable<DalFriend> GetAllUserFriendsByProfileId(int profileId);

        IEnumerable<DalFriend> GetAllUserFriendsByUserIdUsingConformation(int userId, bool confirmed);

        IEnumerable<DalFriend> GetUserFriendsByUserIdAndNameUsingConformation(int userId, string name, bool confirmed);

        IEnumerable<DalFriend> GetUserFriendsByUserIdNameLastNameUsingConformation(int userId, string name, string lastName, bool confirmed);
 

    }
}
