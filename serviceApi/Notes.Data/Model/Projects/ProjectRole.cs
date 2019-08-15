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
    [DisplayName("Notes.Data.Model.Projects.ProjectRole")]
    public class ProjectRole : IEntity, IRemovable
    {
        #region IEntity

        public int Id { get; set; }

        #endregion IEntity

        #region IRemovable

        public bool IsRemoved { get; set; }

        #endregion IRemovable

        #region OwnProperties

        [Required]
        [Column("ProjectId")]
        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        [Required]
        [Column("RoleId")]
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role Role { get; set; }

        #endregion OwnProperties

        #region InverseProperties

        [IgnoreDataMember]
        [InverseProperty("ProjectRole")]
        public virtual ICollection<ProjectRolePermissions> Permissions { get; set; }

        [IgnoreDataMember]
        [InverseProperty("ProjectRole")]
        public virtual ICollection<ProjectRoleUser> Users { get; set; }

        #endregion InverseProperties
    }
}
