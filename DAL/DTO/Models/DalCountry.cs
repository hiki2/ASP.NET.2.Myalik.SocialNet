using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO.Models
{
    public class DalCountry : IDalEntity
    {

        #region Properties

        public int id { get; set; }
        public string Name { get; set; }

        #endregion

    }
}
