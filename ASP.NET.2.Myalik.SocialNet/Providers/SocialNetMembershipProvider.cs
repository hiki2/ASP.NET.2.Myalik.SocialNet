using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using ASP.NET._2.Myalik.SocialNet.Models;
using ASP.NET._2.Myalik.SocialNet.Models.Registration;
using BLL.Services.Interface;
using ASP.NET._2.Myalik.SocialNet.Mappers;
using BLL.Entities;

namespace ASP.NET._2.Myalik.SocialNet.Providers
{
    public class SocialNetMembershipProvider : MembershipProvider
    {
        public IUserService UserService
           => (IUserService)DependencyResolver.Current.GetService(typeof(IUserService));

        public IRoleService RoleService
            => (IRoleService)DependencyResolver.Current.GetService(typeof(IRoleService));

        public IProfileService ProfileService
            => (IProfileService) DependencyResolver.Current.GetService(typeof (IProfileService));

        public override string ApplicationName
        {
            get
            {
                return System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            }
            set { }
        }
    
        public MembershipUser CreateUser(RegisterModel userModel)
        {
            if ((GetUser(userModel.Email, false) != null) || (GetUser(userModel.Mobile) != null))
                return null;
            try
            {
                var profile = new ProfileEntity
                {
                    About = null,
                    Activity = null,
                    Avatar = null,
                    BirthDate = userModel.BirthDate,
                    CountryId = null,
                    FavoriteFilms = null,
                    FavoriteMusic = null,
                    Interests = null,
                    Sex = userModel.Sex,
                    ActivatedDate = DateTime.Now,
                    LastVisitDateTime = DateTime.Now,
                    LastName = userModel.LastName,
                    Name = userModel.FirstName,
                };

                var profileId = ProfileService.CreateEntity(profile).id;

                var user = new UserEntity
                {
                    Email = userModel.Email,
                    Mobile = userModel.Mobile,
                    Password = Encoding.UTF8.GetBytes(Crypto.HashPassword(userModel.Password)),
                    RoleId = RoleService.GetRoleEntityByName("User").id,
                    ProfileId = profileId
                };
                UserService.CreateEntity(user);
            }
            catch
            {
                return null;
            }
            return GetUser(userModel.Mobile);
        }

        public override bool DeleteUser(string email, bool deleteAllRelatedData = false)
        {
            var user = UserService.GetUserEntityByEmail(email);
            if (user == null)
                return false;
            UserService.DeleteEntity(user);
            return true;
        }

        public override bool ValidateUser(string email, string password)
        {
            var user = UserService.GetUserEntityByEmail(email);
            return user != null && Crypto.VerifyHashedPassword(Encoding.UTF8.GetString(user.Password), password);
        }

        public override bool ChangePassword(string email, string oldPassword, string newPassword)
        {
            var user = UserService.GetUserEntityByEmail(email);
            if (user == null || !Crypto.VerifyHashedPassword(Encoding.UTF8.GetString(user.Password), oldPassword))
                return false;
            user.Password = Encoding.UTF8.GetBytes(newPassword);
            UserService.CreateEntity(user);
            return true;
        }

        #region Get User

        public override MembershipUser GetUser(string email, bool userIsOnline)
        {
            var user = UserService.GetUserEntityByEmail(email);
            if (user == null)
                return null;
            var memberUser =
                new MembershipUser("SocialNetMembershipProvider",
                user.Mobile, null, user.Email, null,
                null, false, false, DateTime.MinValue,
                DateTime.MinValue, DateTime.MinValue,
                DateTime.MinValue, DateTime.MinValue);
            return memberUser;
        }

        public MembershipUser GetUser(string mobile)
        {
            var user = UserService.GetUserEntityByMobile(mobile);
            if (user == null)
                return null;
            var memberUser = new MembershipUser("SocialNetMembershipProvider", user.Mobile, null, user.Email,
                null, null, false, false, DateTime.MinValue,
                DateTime.MinValue, DateTime.MinValue,
                DateTime.MinValue, DateTime.MinValue);
            return memberUser;
        }

        #endregion 

        #region Not Implement

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override int MaxInvalidPasswordAttempts
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int MinRequiredPasswordLength
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int PasswordAttemptWindow
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string PasswordStrengthRegularExpression
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool RequiresUniqueEmail
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}