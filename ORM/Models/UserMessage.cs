using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ORM.Models
{
    [Table("UserMessage")]
    public partial class UserMessage : IOrmEntity
    {
        public int id { get; set; }

        public int UserId { get; set; }

        public int ToUserId { get; set; }

        public int MessageId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime PostedDate { get; set; }

        public bool IsRead { get; set; }

        public virtual Message Message { get; set; }

        public virtual User ToUser { get; set; }

        public virtual User User { get; set; }
    }
}
