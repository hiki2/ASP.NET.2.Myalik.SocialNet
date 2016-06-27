using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP.NET._2.Myalik.SocialNet.Models.Interface;

namespace ASP.NET._2.Myalik.SocialNet.Models
{
    public class UserMessageViewModel : IViewModel
    {
        #region Properties

        public int id { get; set; }

        public ProfileViewModel Profile { get; set; }

        public string Message { get; set; }

        public DateTime PostedDate { get; set; }

        public bool IsRead { get; set; }

        public bool Sended { get; set; }

        #endregion 
    }
}