using Notes.Data.Infrastructure;
using Notes.Data.Model.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace Notes.Data.Model.Organizations
{
    [DisplayName("Notes.Data.Model.Organizations.OrganizationRole")]
    public class OrganizationRole : IEntity, IRemovable
    {
        #region IEntity

        public int Id { get; set; }

        #endregion IEntity

        #region IRemovable
        
        public bool IsRemoved { get; set; }

        #endregion IRemovable

        #region OwnProperties

        [Required]
        [ForeignKey("Organization")]
        [Column("OrganizationId")]
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
        
        [Required]
        [ForeignKey("Role")]
        [Column("RoleId")]
        public int RoleId { get; set; }
        public Role Role { get; set; }

        #endregion OwnProperties

        #region InverseProperties

        [IgnoreDataMember]
        [InverseProperty("OrganizationRole")]
        public virtual ICollection<OrganizationRolePermissions> Permissions { get; set; }

        [IgnoreDataMember]
        [InverseProperty("OrganizationRole")]
        public virtual ICollection<OrganizationRoleUser> OrganizationRoleUsers { get; set; }

        #endregion InverseProperties
    }
}
