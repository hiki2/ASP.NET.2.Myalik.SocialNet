﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO.Models
{
    public class DalRole : IDalEntity
    {

        #region Properties

        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        #endregion

    }
}
