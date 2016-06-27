using System;
using BLL.Entities.Interface;

namespace BLL.Entities
{
    public class ProfileEntity : IBllEntity
    {
        #region Properties

        public int id { get; set; }

        public byte[] Avatar { get; set; }

        public DateTime BirthDate { get; set; }

        public int? CountryId { get; set; }

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