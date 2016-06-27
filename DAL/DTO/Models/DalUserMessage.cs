using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO.Models
{
    public class DalUserMessage : IDalEntity
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
