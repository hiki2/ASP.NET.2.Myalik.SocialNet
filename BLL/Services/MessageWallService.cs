using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using BLL.Services.Interface;
using DAL.DTO.Models;
using DAL.Interface;
using BLL.Mappers;

namespace BLL.Services
{
    public class MessageWallService : Service<MessageWallEntity, DalMessageWall>, IMessageWallService
    {
        private readonly IUnitOfWork uow;
        public MessageWallService(IUnitOfWork uow) : base(uow, uow.MessagesWall)
        {
            this.uow = uow;
        }

        public IEnumerable<MessageWallEntity> GetAllWallMessageEntitiesByProfileId(int profileId)
        {
            return uow.MessagesWall.GetAllWallMessagesByProfileId(profileId).Select(Mapper.ToBll);
        }

    }
}
