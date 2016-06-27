using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO;
using DAL.DTO.Models;
using ORM;
using ORM.Models;

namespace DAL.Mappers
{
    public static class Mapper
    {

        #region Methods ToDal

        public static IDalEntity ToDal(IOrmEntity entity)
        {
            return ToDal((dynamic)entity);
        }

        public static DalMessage ToDal(Message message)
        {
            return new DalMessage
            {
                id = message.id,
                MessageBody = message.MessageBody
            };
        }

        public static DalProfile ToDal(Profile profile)
        {
            return new DalProfile
            {
                id = profile.id,
                Avatar = profile.Avatar,
                BirthDate = profile.BirthDate,
                CountryId = profile.CountryId,
                About = profile.About,
                Activity = profile.Activity,
                Interests = profile.Interests,
                FavoriteMusic = profile.FavoriteMusic,
                FavoriteFilms = profile.FavoriteFilms,
                Sex = profile.Sex,
                ActivatedDate = profile.ActivatedDate,
                LastVisitDateTime = profile.LastVisitDateTime,
                Name = profile.Name,
                LastName = profile.LastName
            };
        }

        public static DalUserMessage ToDal(UserMessage userMessage)
        {
            return new DalUserMessage
            {
                id = userMessage.id,
                IsRead = userMessage.IsRead,
                MessageId = userMessage.MessageId,
                PostedDate = userMessage.PostedDate,
                ToUserId = userMessage.ToUserId,
                UserId = userMessage.UserId
            };
        }

        public static DalMessageWall ToDal(MessageWall messageWall)
        {
            return new DalMessageWall
            {
                id = messageWall.id,
                ProfileId = messageWall.ProfileId,
                PostedUserId = messageWall.PostedUserId,
                MessageId = messageWall.MessageId,
                PostedDate = messageWall.PostedDate,
            };
        }

        public static DalCountry ToDal(Country country)
        {
            return new DalCountry
            {
                id = country.id,
                Name = country.Name
            };
        }

        public static DalFriend ToDal(Friend friend)
        {
            return new DalFriend
            {
                id = friend.id,
                UserId = friend.UserId,
                FriendId = friend.FriendId,
                Confirmed = friend.Confirmed,
                RequestDate = friend.RequestDate,
                ConfirmDate = friend.ConfirmDate
            };
        }

        public static DalRole ToDal(Role role)
        {
            return new DalRole
            {
                id = role.id,
                Name = role.Name,
                Description = role.Description
            };
        }

        public static DalUser ToDal(User user)
        {
            return new DalUser
            {
                id = user.id,
                RoleId = user.RoleId,
                Mobile = user.Mobile,
                Password = user.Password,
                Email = user.Email,
                ProfileId = user.ProfileId,
            };
        }
        #endregion

        #region Methods ToOrm

        public static IOrmEntity ToOrm(IDalEntity entity)
        {
            return ToOrm((dynamic)entity);
        }

        public static Message ToOrm(DalMessage message)
        {
            return new Message
            {
                id = message.id,
                MessageBody = message.MessageBody
            };
        }

        public static Profile ToOrm(DalProfile profile)
        {
            return new Profile
            {
                id = profile.id,
                Avatar = profile.Avatar,
                BirthDate = profile.BirthDate,
                CountryId = profile.CountryId,
                About = profile.About,
                Activity = profile.Activity,
                Interests = profile.Interests,
                FavoriteMusic = profile.FavoriteMusic,
                FavoriteFilms = profile.FavoriteFilms,
                Sex = profile.Sex,
                ActivatedDate = profile.ActivatedDate,
                LastVisitDateTime = profile.LastVisitDateTime,
                Name = profile.Name,
                LastName = profile.LastName
            };
        }

        public static UserMessage ToOrm(DalUserMessage userMessage)
        {
            return new UserMessage
            {
                id = userMessage.id,
                IsRead = userMessage.IsRead,
                MessageId = userMessage.MessageId,
                PostedDate = userMessage.PostedDate,
                ToUserId = userMessage.ToUserId,
                UserId = userMessage.UserId
            };
        }

        public static MessageWall ToOrm(DalMessageWall messageWall)
        {
            return new MessageWall
            {
                id = messageWall.id,
                ProfileId = messageWall.ProfileId,
                PostedUserId = messageWall.PostedUserId,
                MessageId = messageWall.MessageId,
                PostedDate = messageWall.PostedDate,
            };
        }

        public static Friend ToOrm(DalFriend friend)
        {
            return new Friend
            {
                id = friend.id,
                UserId = friend.UserId,
                FriendId = friend.FriendId,
                Confirmed = friend.Confirmed,
                RequestDate = friend.RequestDate,
                ConfirmDate = friend.ConfirmDate
            };
        }

        public static Country ToOrm(DalCountry country)
        {
            return new Country
            {
                id = country.id,
                Name = country.Name
            };
        }

        public static Role ToOrm(DalRole role)
        {
            return new Role
            {
                id = role.id,
                Name = role.Name,
                Description = role.Description
            };
        }

        public static User ToOrm(DalUser user)
        {
            return new User
            {
                id = user.id,
                RoleId = user.RoleId,
                Mobile = user.Mobile,
                Password = user.Password,
                Email = user.Email,
                ProfileId = user.ProfileId,
            };
        }

        #endregion

    }
}
