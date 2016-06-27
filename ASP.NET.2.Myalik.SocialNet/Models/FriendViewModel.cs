using System;
using ASP.NET._2.Myalik.SocialNet.Models.Interface;

namespace ASP.NET._2.Myalik.SocialNet.Models
{
    public class FriendViewModel : IViewModel
    {
        #region Properties

        public int id { get; set; }

        public ProfileViewModel Profile { get; set; }

        public bool Confirmed { get; set; }

        public DateTime? RequestDate { get; set; }

        public DateTime? ConfirmDate { get; set; }

        public bool IsRequest { get; set; }

        #endregion
    }
}