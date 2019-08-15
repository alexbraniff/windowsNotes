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
    [DisplayName("Notes.Data.Model.Projects.ProjectRolePermissions")]
    public class ProjectRolePermissions : IEntity, IRemovable
    {
        #region IEntity

        public int Id { get; set; }

        #endregion IEntity

        #region IRemovable

        public bool IsRemoved { get; set; }

        #endregion IRemovable

        #region OwnProperties

        [Required]
        [Column("ProjectRoleId")]
        [ForeignKey("ProjectRole")]
        public int ProjectRoleId { get; set; }
        public ProjectRole ProjectRole { get; set; }

        [Required]
        [Column("PermissionsId")]
        [ForeignKey("Permissions")]
        public int PermissionsId { get; set; }
        public Permissions Permissions { get; set; }

        #endregion OwnProperties

        #region InverseProperties

        #endregion InverseProperties
    }
}
