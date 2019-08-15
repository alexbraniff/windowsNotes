using Notes.Data.Infrastructure;
using Notes.Data.Model.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Data.Model.Notes
{
    [DisplayName("Notes.Data.Model.Notes.NoteUser")]
    public class NoteUser : IEntity, IRemovable
    {
        #region IEntity

        public int Id { get; set; }

        #endregion IEntity

        #region IRemovable

        public bool IsRemoved { get; set; }

        #endregion IRemovable

        #region OwnProperties

        [Required]
        [Column("NoteId")]
        [ForeignKey("Note")]
        public int NoteId { get; set; }
        public Note Note { get; set; }

        [Required]
        [Column("UserId")]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        #endregion OwnProperties

        #region InverseProperties

        [IgnoreDataMember]
        [InverseProperty("NoteUser")]
        public virtual ICollection<NoteUserPermissions> NoteUserPermissionss { get; set; }

        #endregion InverseProperties
    }
}
