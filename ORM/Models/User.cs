using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ORM.Models
{
    [Table("User")]
    public partial class User : IOrmEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Friends = new HashSet<Friend>();
            UserFriends = new HashSet<Friend>();
            MessageWalls = new HashSet<MessageWall>();
            ToUserMessages = new HashSet<UserMessage>();
            UserMessages = new HashSet<UserMessage>();
        }

        public int id { get; set; }

        public int RoleId { get; set; }

        [Required]
        [StringLength(16)]
        public string Mobile { get; set; }

        [Required]
        public byte[] Password { get; set; }

        [Required]
        [StringLength(24)]
        public string Email { get; set; }

        public int ProfileId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Friend> Friends { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Friend> UserFriends { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MessageWall> MessageWalls { get; set; }

        public virtual Profile Profile { get; set; }

        public virtual Role Role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserMessage> ToUserMessages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserMessage> UserMessages { get; set; }
    }
}
