using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Classes;
using DAL.DTO;
using DAL.DTO.Models;
using ORM;
using ORM.Models;

namespace DAL.Interface
{
    public interface IUnitOfWork : IDisposable
    {
     
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
        IFriendRepository Friends { get; }
        IProfileRepository Profiles { get; }
        IMessageWallRepository MessagesWall { get;}
        IUserMessageRepository UserMessages { get; }
        IRepository<DalCountry> Countries { get; }
        IRepository<DalMessage> Messages { get; }

        void Commit();
        //Next Time.
        //void Rollback
    }
}
