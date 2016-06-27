using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO.Models;

namespace DAL.Interface
{
    public interface IUserMessageRepository : IRepository<DalUserMessage>
    {
        IEnumerable<DalUserMessage> GetAllMessagesFromDialog(int userId, int toUserId);
        IEnumerable<DalUserMessage> GetAllUserMessagesByUserId(int userId);
        IEnumerable<DalUserMessage> GetAllUserMessagesByProfileId(int profileId);
    }
}
