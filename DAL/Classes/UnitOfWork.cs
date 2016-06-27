using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO;
using DAL.DTO.Models;
using DAL.Interface;
using ORM;
using ORM.Models;

namespace DAL.Classes
{
    public class UnitOfWork : IUnitOfWork
    {
        public SocialNetDB db { get; }

        private UserRepository userRepository;
        private RoleRepository roleRepository;
        private FriendRepository friendRepository;
        private ProfileRepository profileRepository;
        private MessageWallRepository messageWallRepository;
        private UserMessageRepository userMessageRepository;
        private Repository<DalCountry, Country> repository;
        private Repository<DalMessage, Message> messageRepository;
        public IRepository<DalCountry> Countries
            => repository ?? (repository = new Repository<DalCountry, Country>(db));

        public IUserRepository Users
            => userRepository ?? (userRepository = new UserRepository(db));

        public IRoleRepository Roles 
            => roleRepository ?? (roleRepository = new RoleRepository(db));

        public IFriendRepository Friends
            => friendRepository ?? (friendRepository = new FriendRepository(db));

        public IProfileRepository Profiles
            => profileRepository ?? (profileRepository = new ProfileRepository(db));

        public IMessageWallRepository MessagesWall
            => messageWallRepository ?? (messageWallRepository = new MessageWallRepository(db));

        public IUserMessageRepository UserMessages
            => userMessageRepository ?? (userMessageRepository = new UserMessageRepository(db));

        public IRepository<DalMessage> Messages
            => messageRepository ?? (messageRepository = new Repository<DalMessage, Message>(db));

        public UnitOfWork(SocialNetDB context)
        {
            db = context;
        }

        public void Commit()
        {
            db.SaveChanges();
        }

        private bool disposed;

        public virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                db.Dispose();
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
