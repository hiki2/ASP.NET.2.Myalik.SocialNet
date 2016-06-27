using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;

namespace BLL.Services.Interface
{
    public interface IUserMessageService : IService<UserMessageEntity>
    {
        IEnumerable<UserMessageEntity> GetAllMessageEntitiesFromDialog(int userId, int toUserId);
        IEnumerable<UserMessageEntity> GetAllUserMessageEntitiesByUserId(int userId);
        IEnumerable<UserMessageEntity> GetAllUserMessageEntitiesByProfileId(int profileId);
    }
}
