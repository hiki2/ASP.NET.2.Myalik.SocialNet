using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO.Models;
using ORM.Models;
using DAL.Interface;
using DAL.Mappers;
using ORM;

namespace DAL.Classes
{
    public class UserMessageRepository : Repository<DalUserMessage, UserMessage>, IUserMessageRepository
    {
        private readonly SocialNetDB context;

        public UserMessageRepository(SocialNetDB uow) : base(uow)
        {
            context = uow;
        }

        public IEnumerable<DalUserMessage> GetAllMessagesFromDialog(int userId, int toUserId)
        {
            return context.UserMessages.Where(userMessage => 
            (userMessage.UserId == userId) 
            && (userMessage.ToUserId == toUserId))
            .Select(Mapper.ToDal);
        }

        public IEnumerable<DalUserMessage> GetAllUserMessagesByProfileId(int profileId)
        {
            return context.UserMessages.Where(message =>
                (message.User.Profile.id == profileId)
                || (message.ToUser.Profile.id == profileId)).Select(Mapper.ToDal);
        }

        public IEnumerable<DalUserMessage> GetAllUserMessagesByUserId(int userId)
        {
            return context.UserMessages.Where(message => (message.User.id == userId) || (message.ToUser.id == userId)).Select(Mapper.ToDal);
        }
    }
}
