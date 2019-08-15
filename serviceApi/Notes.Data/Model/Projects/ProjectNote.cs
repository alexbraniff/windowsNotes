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

namespace Notes.Data.Model.Projects
{
    [DisplayName("Notes.Data.Model.Projects.ProjectNote")]
    public class ProjectNote : IEntity, IRemovable
    {
        #region IEntity

        public int Id { get; set; }

        #endregion IEntity

        #region IRemovable
        
        public bool IsRemoved { get; set; }

        #endregion IRemovable

        #region OwnProperties

        [Required]
        [ForeignKey("Project")]
        [Column("ProjectId")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        [Required]
        [ForeignKey("Note")]
        [Column("NoteId")]
        public int NoteId { get; set; }
        public Note Note { get; set; }

        #endregion OwnProperties

        #region InverseProperties

        [IgnoreDataMember]
        [InverseProperty("ProjectNote")]
        public virtual ICollection<ProjectNoteRole> Roles { get; set; }

        [IgnoreDataMember]
        [InverseProperty("ProjectNote")]
        public virtual ICollection<ProjectNoteUser> Users { get; set; }

        #endregion InverseProperties
    }
}
