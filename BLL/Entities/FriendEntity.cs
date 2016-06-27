using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities.Interface;

namespace BLL.Entities
{
    public class FriendEntity : IBllEntity
    {
        #region Properties

        public int id { get; set; }

        public int UserId { get; set; }

        public int FriendId { get; set; }

        public bool Confirmed { get; set; }

        public DateTime? RequestDate { get; set; }

        public DateTime? ConfirmDate { get; set; }

        #endregion
    }
}
