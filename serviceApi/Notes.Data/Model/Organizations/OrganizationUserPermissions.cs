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

namespace Notes.Data.Model.Organizations
{
    [DisplayName("Notes.Data.Model.Organizations.OrganizationUserPermissions")]
    public class OrganizationUserPermissions : IEntity, IRemovable
    {
        #region IEntity

        public int Id { get; set; }

        #endregion IEntity

        #region IRemovable

        [Required]
        [Column("IsRemoved")]
        public bool IsRemoved { get; set; }

        #endregion IRemovable

        #region OwnProperties

        [Required]
        [ForeignKey("OrganizationUser")]
        [Column("OrganizationUserId")]
        public int OrganizationUserId { get; set; }
        public OrganizationUser OrganizationUser { get; set; }

        [Required]
        [ForeignKey("Permissions")]
        [Column("PermissionsId")]
        public int PermissionsId { get; set; }
        public Permissions Permissions { get; set; }

        #endregion OwnProperties

        #region InverseProperties

        #endregion InverseProperties
    }
}
