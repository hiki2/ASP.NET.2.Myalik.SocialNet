using System;
using BLL.Entities.Interface;

namespace BLL.Entities
{
    public class UserMessageEntity : IBllEntity
    {
        #region Properties

        public int id { get; set; }

        public int UserId { get; set; }

        public int ToUserId { get; set; }

        public int MessageId { get; set; }

        public DateTime PostedDate { get; set; }

        public bool IsRead { get; set; }

        #endregion 
    }
}