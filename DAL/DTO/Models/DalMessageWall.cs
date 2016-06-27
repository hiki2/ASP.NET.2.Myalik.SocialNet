using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO.Models
{
    public class DalMessageWall : IDalEntity
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
