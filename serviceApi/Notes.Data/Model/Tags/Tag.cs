using Notes.Data.Infrastructure;
using Notes.Data.Model.Notes;
using Notes.Data.Model.Organizations;
using Notes.Data.Model.Projects;
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

namespace Notes.Data.Model.Tags
{
    [DisplayName("Notes.Data.Model.Tags.Tag")]
    public class Tag : IEntity, IRemovable, IStylable<TagStyle>
    {
        #region IEntity

        public int Id { get; set; }

        #endregion IEntity

        #region IRemovable

        public bool IsRemoved { get; set; }

        #endregion IRemovable

        #region IStylable

        public int? StyleId { get; set; }
        public TagStyle Style { get; set; }

        #endregion IStylable

        #region InverseProperties

        [IgnoreDataMember]
        [InverseProperty("Tag")]
        public virtual ICollection<NoteTag> Notes { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Tag")]
        public virtual ICollection<OrganizationTag> Organizations { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Tag")]
        public virtual ICollection<ProjectTag> Projects { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Tag")]
        public virtual ICollection<UserTag> Users { get; set; }

        #endregion InverseProperties
    }
}
