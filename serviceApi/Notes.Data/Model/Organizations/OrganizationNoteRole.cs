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
    [DisplayName("Notes.Data.Model.Organizations.OrganizationNoteRole")]
    public class OrganizationNoteRole : IEntity, IRemovable
    {
        #region IEntity

        public int Id { get; set; }

        #endregion IEntity

        #region IRemovable

        public bool IsRemoved { get; set; }

        #endregion IRemovable

        #region OwnProperties

        [Required]
        [Column("OrganizationNoteId")]
        [ForeignKey("OrganizationNote")]
        public int OrganizationNoteId { get; set; }
        public OrganizationNote OrganizationNote { get; set; }

        [Required]
        [Column("RoleId")]
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role Role { get; set; }

        #endregion OwnProperties

        #region InverseProperties

        [IgnoreDataMember]
        [InverseProperty("OrganizationNoteRole")]
        public virtual ICollection<OrganizationNoteRolePermissions> Permissions { get; set; }

        [IgnoreDataMember]
        [InverseProperty("OrganizationNoteRole")]
        public virtual ICollection<OrganizationNoteRoleUser> Users { get; set; }

        #endregion InverseProperties
    }
}
