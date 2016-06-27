using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO.Models;
using DAL.Interface;
using DAL.Mappers;
using ORM.Models;
using ORM;

namespace DAL.Classes
{
    public class MessageWallRepository : Repository<DalMessageWall,MessageWall>, IMessageWallRepository
    {
        private readonly SocialNetDB context;

        public MessageWallRepository(SocialNetDB uow) : base(uow)
        {
            context = uow;
        }

        public IEnumerable<DalMessageWall> GetAllWallMessagesByProfileId(int profileId)
        {
            return context.MessageWalls.Where(messageWall => messageWall.ProfileId == profileId).Select(Mapper.ToDal);
        }

    }
}
