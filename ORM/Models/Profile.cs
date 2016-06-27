using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ORM.Models
{
    [Table("Profile")]
    public partial class Profile : IOrmEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Profile()
        {
            MessageWalls = new HashSet<MessageWall>();
            Users = new HashSet<User>();
        }

        public int id { get; set; }

        public int? CountryId { get; set; }

        public byte[] Avatar { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime BirthDate { get; set; }

        [Column(TypeName = "ntext")]
        public string About { get; set; }

        [Column(TypeName = "ntext")]
        public string Activity { get; set; }

        [Column(TypeName = "ntext")]
        public string Interests { get; set; }

        [Column(TypeName = "ntext")]
        public string FavoriteMusic { get; set; }

        [Column(TypeName = "ntext")]
        public string FavoriteFilms { get; set; }

        public bool Sex { get; set; }

        [Required]
        [StringLength(24)]
        public string Name { get; set; }

        [Required]
        [StringLength(24)]
        public string LastName { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime LastVisitDateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ActivatedDate { get; set; }

        public virtual Country Country { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MessageWall> MessageWalls { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }
    }
}
