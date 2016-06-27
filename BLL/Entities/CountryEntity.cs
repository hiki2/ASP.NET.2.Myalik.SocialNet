using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities.Interface;

namespace BLL.Entities
{
    public class CountryEntity : IBllEntity
    {
        #region Properties

        public int id { get; set; }
        public string Name { get; set; }

        #endregion
    }
}
