using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP.NET._2.Myalik.SocialNet.Models;
using ASP.NET._2.Myalik.SocialNet.Models.Interface;
using ASP.NET._2.Myalik.SocialNet.Models.Registration;
using BLL.Entities;
using BLL.Entities.Interface;

namespace ASP.NET._2.Myalik.SocialNet.Mappers
{
    public static class Mapper
    {
        #region Methods ToView

        public static IViewModel ToView(IBllEntity entity)
        {
            return ToView((dynamic)entity);
        }

        public static MessageViewModel ToView(MessageEntity message)
        {
            return new MessageViewModel
            {
                id = message.id,
                MessageBody = message.MessageBody
            };
        }

        public static ProfileViewModel ToView(ProfileEntity profile)
        {
            return new ProfileViewModel
            {
                id = profile.id,
                Avatar = profile.Avatar,
                BirthDate = profile.BirthDate,            
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

        public static UserMessageViewModel ToView(UserMessageEntity userMessage)
        {
            return new UserMessageViewModel
            {
                id = userMessage.id,
                IsRead = userMessage.IsRead,
                PostedDate = userMessage.PostedDate
            };
        }

        public static MessageWallViewModel ToView(MessageWallEntity messageWall)
        {
            return new MessageWallViewModel
            {
                id = messageWall.id,
                PosteDate = messageWall.PostedDate
            };
        }


        public static FriendViewModel ToView(FriendEntity friend)
        {
            return new FriendViewModel
            {
                id = friend.id,
                Confirmed = friend.Confirmed,
                RequestDate = friend.RequestDate,
                ConfirmDate = friend.ConfirmDate
            };
        }


        public static UserViewModel ToView(UserEntity user)
        {
            return new UserViewModel
            {
                id = user.id,
                Mobile = user.Mobile,
                Password = user.Password,
                Email = user.Email,
                Role = (RoleViewModel)user.RoleId
            };
        }

        public static SeachViewModel ToView(SearchEntity search)
        {
            return new SeachViewModel
            {
                Country = search.Country,
                NameAndSurName = search.NameAndSurName,
                Sex = search.Sex
            };
        }

        public static CountryViewModel ToView(CountryEntity country)
        {
            return new CountryViewModel
            {
                id = country.id,
                Name = country.Name
            };
        }
        #endregion

        #region Methods ToBll

        public static IBllEntity ToBll(IViewModel entity)
        {
            return ToBll((dynamic)entity);
        }

        public static MessageEntity ToBll(MessageViewModel message)
        {
            return new MessageEntity
            {
                id = message.id,
                MessageBody = message.MessageBody
            };
        }

        public static ProfileEntity ToBll(ProfileViewModel profile)
        {
            return new ProfileEntity
            {
                id = profile.id,
                Avatar = profile.Avatar,
                BirthDate = profile.BirthDate,
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

        public static UserMessageEntity ToBll(UserMessageViewModel userMessage)
        {
            return new UserMessageEntity
            {
                id = userMessage.id,
                IsRead = userMessage.IsRead,
                PostedDate = userMessage.PostedDate
            };
        }

        public static MessageWallEntity ToBll(MessageWallViewModel messageWall)
        {
            return new MessageWallEntity
            {
                id = messageWall.id,
            };
        }

        public static FriendEntity ToBll(FriendViewModel friend)
        {
            return new FriendEntity
            {
                id = friend.id,
                Confirmed = friend.Confirmed,
                RequestDate = friend.RequestDate,
                ConfirmDate = friend.ConfirmDate
            };
        }

        public static UserEntity ToBll(UserViewModel user)
        {
            return new UserEntity
            {
                id = user.id,
                Mobile = user.Mobile,
                Password = user.Password,
                Email = user.Email,
                RoleId = (int)user.Role
            };
        }
        public static SearchEntity ToBll(SeachViewModel search)
        {
            return new SearchEntity
            {
                Country = search.Country,
                NameAndSurName = search.NameAndSurName,
                Sex = search.Sex
            };
        }

        public static CountryEntity ToBll(CountryViewModel country)
        {
            return new CountryEntity
            {
                id = country.id,
                Name = country.Name
            };
        }
        #endregion
    }
}