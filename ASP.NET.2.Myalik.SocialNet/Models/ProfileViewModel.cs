using System;
using System.Web.Profile;
using System.Web.Security;
using ASP.NET._2.Myalik.SocialNet.Models.Interface;
using ASP.NET._2.Myalik.SocialNet.Providers;

namespace ASP.NET._2.Myalik.SocialNet.Models
{
    public class ProfileViewModel : IViewModel
    {

        #region Properties

        public int id { get; set; }

        public byte[] Avatar { get; set; }

        public DateTime BirthDate { get; set; }

        public string Country { get; set; }

        public string About { get; set; }

        public string Activity { get; set; }

        public string Interests { get; set; }

        public string FavoriteMusic { get; set; }

        public string FavoriteFilms { get; set; }

        public bool Sex { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime LastVisitDateTime { get; set; }

        public DateTime ActivatedDate { get; set; }

        #endregion      
    }
}