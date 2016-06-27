using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP.NET._2.Myalik.SocialNet.Models.Interface;

namespace ASP.NET._2.Myalik.SocialNet.Models
{
    public class UserViewModel : IViewModel
    {
        #region Properties

        public int id { get; set; }

        public RoleViewModel Role { get; set; }

        public string Mobile { get; set; }

        public byte[] Password { get; set; }

        public string Email { get; set; }


        #endregion
    }
}