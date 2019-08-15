using Notes.Data.Infrastructure;
using Notes.Data.Model.Security;
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
    [DisplayName("Notes.Data.Model.Projects.ProjectNoteRole")]
    public class ProjectNoteRole : IEntity, IRemovable
    {
        #region IEntity

        public int Id { get; set; }

        #endregion IEntity

        #region IRemovable
        
        public bool IsRemoved { get; set; }

        #endregion IRemovable

        #region OwnProperties

        [Required]
        [ForeignKey("ProjectNote")]
        [Column("ProjectNoteId")]
        public int ProjectNoteId { get; set; }
        public ProjectNote ProjectNote { get; set; }

        [Required]
        [ForeignKey("Role")]
        [Column("RoleId")]
        public int RoleId { get; set; }
        public Role Role { get; set; }

        #endregion OwnProperties

        #region InverseProperties

        [IgnoreDataMember]
        [InverseProperty("ProjectNoteRole")]
        public virtual ICollection<ProjectNoteRolePermissions> Permissions { get; set; }

        [IgnoreDataMember]
        [InverseProperty("ProjectNoteRole")]
        public virtual ICollection<ProjectNoteRoleUser> Users { get; set; }

        #endregion InverseProperties
    }
}
