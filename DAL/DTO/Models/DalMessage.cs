using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO.Models
{
    public class DalMessage : IDalEntity
    {

        #region Properties

        public int id { get; set; }

        public string MessageBody { get; set; }

        #endregion

    }
}
