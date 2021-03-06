﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO.Models
{
    public class DalUser : IDalEntity
    {

        #region Properties

        public int id { get; set; }

        public int RoleId { get; set; }

        public int ProfileId { get; set; }

        public string Mobile { get; set; }

        public byte[] Password { get; set; }

        public string Email { get; set; }

        #endregion

    }
}
