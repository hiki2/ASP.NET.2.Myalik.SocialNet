using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ORM.Models
{
    [Table("MessageWall")]
    public partial class MessageWall : IOrmEntity
    {
        public int id { get; set; }

        public int ProfileId { get; set; }

        public int PostedUserId { get; set; }

        public int MessageId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime PostedDate { get; set; }

        public virtual Message Message { get; set; }

        public virtual Profile Profile { get; set; }

        public virtual User User { get; set; }
    }
}
