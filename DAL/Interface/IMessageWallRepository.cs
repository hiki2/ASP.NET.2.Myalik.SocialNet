using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO.Models;
using ORM.Models;

namespace DAL.Interface
{
    public interface IMessageWallRepository : IRepository<DalMessageWall>
    {
        IEnumerable<DalMessageWall> GetAllWallMessagesByProfileId(int profileId);
    }
}
