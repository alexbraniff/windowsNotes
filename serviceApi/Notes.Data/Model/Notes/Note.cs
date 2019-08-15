using Notes.Data.Infrastructure;
using Notes.Data.Model.Organizations;
using Notes.Data.Model.Projects;
using Notes.Data.Model.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Notes.Data.Model.Notes
{
    [DisplayName("Notes.Data.Model.Notes.Note")]
    public class Note : IEntityTree<Note>, IRemovable, IStylable<NoteStyle>
    {
        #region IEntity

        public int Id { get; set; }

        #endregion IEntity

        #region IEntityTree

        public int? ParentId { get; set; }
        public Note Parent { get; set; }

        public virtual ICollection<Note> Children { get; set; }

        #endregion IEntityTree

        #region IRemovable

        public bool IsRemoved { get; set; }

        #endregion IRemovable

        #region IStylable
        
        public int? StyleId { get; set; }
        public NoteStyle Style { get; set; }

        #endregion IStylable

        #region OwnProperties
        [Column("Title")]
        public string Title { get; set; }
        [Column("Content")]
        public string Content { get; set; }

        #endregion OwnProperties

        #region InverseProperties

        [IgnoreDataMember]
        [InverseProperty("Note")]
        public virtual ICollection<NoteTag> Tags { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Note")]
        public virtual ICollection<NoteUser> Users { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Note")]
        public virtual ICollection<OrganizationNote> Organizations { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Note")]
        public virtual ICollection<ProjectNote> Projects { get; set; }

        #endregion InverseProperties
    }
}
