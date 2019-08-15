using Notes.Data.Infrastructure;
using Notes.Data.Model.Tags;
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
    [DisplayName("Notes.Data.Model.Notes.NoteTag")]
    public class NoteTag : IEntity, IRemovable
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
        [Column("TagId")]
        [ForeignKey("Tag")]
        public int TagId { get; set; }
        public Tag Tag { get; set; }

        #endregion OwnProperties

        #region InverseProperties

        #endregion InverseProperties
    }
}
