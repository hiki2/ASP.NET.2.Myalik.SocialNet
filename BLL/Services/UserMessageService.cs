using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using BLL.Services.Interface;
using DAL.DTO.Models;
using DAL.Interface;
using BLL.Mappers;

namespace BLL.Services
{
    public class UserMessageService : Service<UserMessageEntity, DalUserMessage>, IUserMessageService
    {
        private readonly IUnitOfWork uow;
        public UserMessageService(IUnitOfWork uow) : base(uow, uow.UserMessages)
        {
            this.uow = uow;
        }

        public IEnumerable<UserMessageEntity> GetAllMessageEntitiesFromDialog(int userId, int toUserId)
        {
            return uow.UserMessages.GetAllMessagesFromDialog(userId, toUserId).Select(Mapper.ToBll);
        }

        public IEnumerable<UserMessageEntity> GetAllUserMessageEntitiesByProfileId(int profileId)
        {
            return uow.UserMessages.GetAllUserMessagesByProfileId(profileId).Select(Mapper.ToBll);
        }

        public IEnumerable<UserMessageEntity> GetAllUserMessageEntitiesByUserId(int userId)
        {
            return uow.UserMessages.GetAllUserMessagesByUserId(userId).Select(Mapper.ToBll);
        }
    }
}
