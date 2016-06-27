using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ORM.Models
{
    [Table("Friend")]
    public partial class Friend : IOrmEntity
    {
        public int id { get; set; }

        public int UserId { get; set; }

        public int FriendId { get; set; }

        public bool Confirmed { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? RequestDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ConfirmDate { get; set; }

        public virtual User UserFriend { get; set; }

        public virtual User User { get; set; }
    }
}
