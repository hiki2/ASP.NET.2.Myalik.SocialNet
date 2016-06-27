using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using BLL.Entities.Interface;
using DAL.DTO;
using DAL.DTO.Models;

namespace BLL.Mappers
{
    public static class Mapper
    {
        #region Methods ToDal

        public static IDalEntity ToDal(IBllEntity entity)
        {
            return ToDal((dynamic)entity);
        }

        public static DalMessage ToDal(MessageEntity message)
        {
            return new DalMessage
            {
                id = message.id,
                MessageBody = message.MessageBody
            };
        }

        public static DalProfile ToDal(ProfileEntity profile)
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
                Name = profile.Name,
                LastName = profile.LastName,
                ActivatedDate = profile.ActivatedDate,
                LastVisitDateTime = profile.LastVisitDateTime
            };
        }

        public static DalUserMessage ToDal(UserMessageEntity userMessage)
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

        public static DalMessageWall ToDal(MessageWallEntity messageWall)
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

        public static DalCountry ToDal(CountryEntity country)
        {
            return new DalCountry
            {
                id = country.id,
                Name = country.Name
            };
        }

        public static DalFriend ToDal(FriendEntity friend)
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

        public static DalRole ToDal(RoleEntity role)
        {
            return new DalRole
            {
                id = role.id,
                Name = role.Name,
                Description = role.Description
            };
        }

        public static DalUser ToDal(UserEntity user)
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

        public static DalSearch ToDal(SearchEntity search)
        {
            return new DalSearch
            {
                Country = search.Country,
                NameAndSurName = search.NameAndSurName,
                Sex = search.Sex
            };
        }
        #endregion

        #region Methods ToBll

        public static IBllEntity ToBll(IDalEntity entity)
        {
            return ToBll((dynamic)entity);
        }

        public static MessageEntity ToBll(DalMessage message)
        {
            return new MessageEntity
            {
                id = message.id,
                MessageBody = message.MessageBody
            };
        }

        public static ProfileEntity ToBll(DalProfile profile)
        {
            return new ProfileEntity
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
                Name = profile.Name,
                LastName = profile.LastName,
                ActivatedDate = profile.ActivatedDate,
                LastVisitDateTime = profile.LastVisitDateTime
            };
        }

        public static UserMessageEntity ToBll(DalUserMessage userMessage)
        {
            return new UserMessageEntity
            {
                id = userMessage.id,
                IsRead = userMessage.IsRead,
                MessageId = userMessage.MessageId,
                PostedDate = userMessage.PostedDate,
                ToUserId = userMessage.ToUserId,
                UserId = userMessage.UserId
            };
        }

        public static MessageWallEntity ToBll(DalMessageWall messageWall)
        {
            return new MessageWallEntity
            {
                id = messageWall.id,
                ProfileId = messageWall.ProfileId,
                PostedUserId = messageWall.PostedUserId,
                MessageId = messageWall.MessageId,
                PostedDate = messageWall.PostedDate,
            };
        }

        public static FriendEntity ToBll(DalFriend friend)
        {
            return new FriendEntity
            {
                id = friend.id,
                UserId = friend.UserId,
                FriendId = friend.FriendId,
                Confirmed = friend.Confirmed,
                RequestDate = friend.RequestDate,
                ConfirmDate = friend.ConfirmDate
            };
        }

        public static CountryEntity ToBll(DalCountry country)
        {
            return new CountryEntity
            {
                id = country.id,
                Name = country.Name
            };
        }

        public static RoleEntity ToBll(DalRole role)
        {
            return new RoleEntity
            {
                id = role.id,
                Name = role.Name,
                Description = role.Description
            };
        }

        public static UserEntity ToBll(DalUser user)
        {
            return new UserEntity
            {
                id = user.id,
                RoleId = user.RoleId,
                Mobile = user.Mobile,
                Password = user.Password,
                Email = user.Email,
                ProfileId = user.ProfileId,
            };
        }
        public static SearchEntity ToBll(DalSearch search)
        {
            return new SearchEntity
            {
                Country = search.Country,
                NameAndSurName = search.NameAndSurName,
                Sex = search.Sex
            };
        }
        #endregion
    }
}
