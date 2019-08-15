using Notes.Data.Infrastructure;
using Notes.Data.Model.Notes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Data.Model.Organizations
{
    [DisplayName("Notes.Data.Model.Organizations.OrganizationNote")]
    public class OrganizationNote : IEntity, IRemovable
    {
        #region IEntity

        public int Id { get; set; }

        #endregion IEntity

        #region IRemovable

        public bool IsRemoved { get; set; }

        #endregion IRemovable

        #region OwnProperties

        [Required]
        [Column("OrganizationId")]
        [ForeignKey("Organization")]
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }

        [Required]
        [Column("NoteId")]
        [ForeignKey("Note")]
        public int NoteId { get; set; }
        public Note Note { get; set; }

        #endregion OwnProperties

        #region InverseProperties

        [IgnoreDataMember]
        [InverseProperty("OrganizationNote")]
        public virtual ICollection<OrganizationNoteRole> Roles { get; set; }

        [IgnoreDataMember]
        [InverseProperty("OrganizationNote")]
        public virtual ICollection<OrganizationNoteUser> Users { get; set; }

        #endregion InverseProperties
    }
}
