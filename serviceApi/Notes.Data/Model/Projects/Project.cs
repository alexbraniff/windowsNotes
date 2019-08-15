using Notes.Data.Infrastructure;
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
    [DisplayName("Notes.Data.Model.Projects.Project")]
    public class Project : IEntity, IRemovable, IStylable<ProjectStyle>
    {
        #region IEntity

        public int Id { get; set; }

        #endregion IEntity

        #region IRemovable

        public bool IsRemoved { get; set; }

        #endregion IRemovable

        #region IStylable

        public int? StyleId { get; set; }
        public ProjectStyle Style { get; set; }

        #endregion IStylable

        #region OwnProperties

        #endregion OwnProperties

        #region InverseProperties

        [IgnoreDataMember]
        [InverseProperty("Project")]
        public virtual ICollection<ProjectNote> Notes { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Project")]
        public virtual ICollection<ProjectRole> Roles { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Project")]
        public virtual ICollection<ProjectTag> Tags { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Project")]
        public virtual ICollection<ProjectUser> Users { get; set; }

        #endregion InverseProperties
    }
}
