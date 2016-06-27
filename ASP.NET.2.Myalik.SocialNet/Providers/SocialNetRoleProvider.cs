using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Entities;
using BLL.Services.Interface;

namespace ASP.NET._2.Myalik.SocialNet.Providers
{
    public class SocialNetRoleProvider : RoleProvider
    {

        public override string ApplicationName
        {
            get
            {
                return System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            }
            set { }
        }

        public IUserService UserService
            => (IUserService)DependencyResolver.Current.GetService(typeof(IUserService));

        public IRoleService RoleService
            => (IRoleService)DependencyResolver.Current.GetService(typeof(IRoleService));

        public override bool IsUserInRole(string email, string roleName)
        {
            var user = UserService.GetUserEntityByEmail(email);
            if (user == null) return false;
            var role = RoleService.GetRoleEntityByName(roleName);
            return role?.id == user.RoleId;
        }

        public override string[] GetRolesForUser(string email)
        {
            var user = UserService.GetUserEntityByEmail(email);
            return user == null ? null : new[] { RoleService.GetEntity(user.RoleId).Name };
        }

        public override void CreateRole(string roleName)
        {
            if (RoleService.GetRoleEntityByName(roleName) != null)
                RoleService.CreateEntity(new RoleEntity {Description = roleName, Name = roleName});        
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            if (throwOnPopulatedRole)
            {
                if(UserService.GetUserEntitiesByRoleName(roleName).Any())
                    throw new InvalidOperationException(nameof(roleName));
            }
            var entity = RoleService.GetRoleEntityByName(roleName);
            RoleService.DeleteEntity(entity);
            return entity != null;
        }

        public override bool RoleExists(string roleName)
        {
            var entity = RoleService.GetRoleEntityByName(roleName);
            return entity != null;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            return UserService.GetUserEntitiesByRoleName(roleName).Select(user => user.Email).ToArray();
        }

        public override string[] GetAllRoles()
        {
            return RoleService.GetALLEntities().Select(role => role.Name).ToArray();
        }

        #region Not Implemented

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}