using System;
using BLL.Entities.Interface;

namespace BLL.Entities
{
    public class MessageWallEntity : IBllEntity
    {
        #region Properties

        public int id { get; set; }

        public int ProfileId { get; set; }

        public int PostedUserId { get; set; }

        public int MessageId { get; set; }

        public DateTime PostedDate { get; set; }

        #endregion 
    }
}