using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP.NET._2.Myalik.SocialNet.Models.Interface;

namespace ASP.NET._2.Myalik.SocialNet.Models
{
    public class PageViewModel
    {
        public UserViewModel User { get; set; }
        public ProfileViewModel Profile { get; set; }
        public IEnumerable<MessageWallViewModel> MessageWall { get; set; }
        public IEnumerable<FriendViewModel> Friends { get; set; }
    }
}