using System;
using ASP.NET._2.Myalik.SocialNet.Models.Interface;

namespace ASP.NET._2.Myalik.SocialNet.Models
{
    public class MessageWallViewModel : IViewModel
    {
        #region Properties

        public int id { get; set; }

        public DateTime PosteDate { get; set; }

        public ProfileViewModel PostedUser { get; set; }

        public MessageViewModel Message { get; set; }

        #endregion      
    }
}