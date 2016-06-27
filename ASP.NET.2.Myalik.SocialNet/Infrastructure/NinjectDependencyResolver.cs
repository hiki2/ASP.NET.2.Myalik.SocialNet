using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using BLL.Entities;
using BLL.Services;
using BLL.Services.Interface;
using Ninject;

namespace ASP.NET._2.Myalik.SocialNet.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IFriendService>().To<FriendService>();
            kernel.Bind<IMessageWallService>().To<MessageWallService>();
            kernel.Bind<IProfileService>().To<ProfileService>();
            kernel.Bind<IRoleService>().To<RoleService>();
            kernel.Bind<IUserMessageService>().To<UserMessageService>();
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IService<CountryEntity>>().To<CountryService>();
            kernel.Bind<IService<MessageEntity>>().To<MessageService>();
        }
    }
}