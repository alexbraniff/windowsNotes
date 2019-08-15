using Notes.Data.Infrastructure;
using Notes.Data.Model.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace Notes.Data.Model.Audit
{
    [DisplayName("Notes.Data.Model.Audit.AuditUpdate")]
    public class AuditUpdate : IEntity, IAudit
    {
        #region IEntity

        public int Id { get; set; }

        #endregion IIEntity

        #region IAudit

        [Required]
        [Column("Timestamp")]
        public DateTime Timestamp { get; set; }

        [Required]
        [Column("UserId")]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        [Column("Entity")]
        public string Entity { get; set; }

        [Required]
        [Column("EntityId")]
        public int EntityId { get; set; }

        #endregion IAudit

        #region OwnProperties

        [Required]
        [Column("Field")]
        public string Field { get; set; }

        [Required]
        [Column("From")]
        public string From { get; set; }

        [Required]
        [Column("To")]
        public string To { get; set; }

        #endregion OwnProperties
    }
}
