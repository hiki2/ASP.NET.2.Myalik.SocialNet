using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Mappers;
using ORM;

namespace DAL.DTO
{
    public interface IDalEntity
    {

        #region Properties

        int id { get; set; }

        #endregion

    }
}
