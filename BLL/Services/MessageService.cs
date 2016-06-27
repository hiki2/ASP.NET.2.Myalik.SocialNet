using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using BLL.Services.Interface;
using DAL.DTO.Models;
using BLL.Services;
using DAL.Interface;

namespace BLL.Services
{
    public class MessageService : Service<MessageEntity, DalMessage>
    {
        public MessageService(IUnitOfWork uow) : base(uow, uow.Messages){ }
    }
}
