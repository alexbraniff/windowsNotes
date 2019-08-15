using Notes.Data.Infrastructure;
using Notes.Data.Model.Notes;
using Notes.Data.Model.Organizations;
using Notes.Data.Model.Projects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Data.Model.Security
{
    [DisplayName("Notes.Data.Model.OrganizationsNoteUserPermissions")]
    public class Permissions : IEntity, IRemovable
    {
        #region IEntity

        public int Id { get; set; }

        #endregion IEntity

        #region IRemovable
        
        public bool IsRemoved { get; set; }

        #endregion IRemovable

        #region OwnProperties

        [Required]
        [Column("CanView")]
        public bool CanView { get; set; }

        [Required]
        [Column("CanEditContent")]
        public bool CanEditContent { get; set; }

        [Required]
        [Column("CanArchive")]
        public bool CanArchive { get; set; }

        [Required]
        [Column("CanViewArchived")]
        public bool CanViewArchived { get; set; }

        [Required]
        [Column("CanEditArchived")]
        public bool CanEditArchived { get; set; }

        [Required]
        [Column("CanUnArchive")]
        public bool CanUnArchive { get; set; }

        [Required]
        [Column("CanAddTags")]
        public bool CanAddTags { get; set; }

        [Required]
        [Column("CanRemoveTags")]
        public bool CanRemoveTags { get; set; }

        [Required]
        [Column("CanChangeStyle")]
        public bool CanChangeStyle { get; set; }

        [Required]
        [Column("CanReassign")]
        public bool CanReassign { get; set; }

        [Required]
        [Column("CanReorder")]
        public bool CanReorder { get; set; }

        [Required]
        [Column("CanEditStatus")]
        public bool CanEditStatus { get; set; }

        [Required]
        [Column("CanEditUserPermissions")]
        public bool CanEditUserPermissions { get; set; }

        [Required]
        [Column("CanAddUsers")]
        public bool CanAddUsers { get; set; }

        [Required]
        [Column("CanRemoveUsers")]
        public bool CanRemoveUsers { get; set; }

        [Required]
        [Column("CanAddRoles")]
        public bool CanAddRoles { get; set; }

        [Required]
        [Column("CanRemoveRoles")]
        public bool CanRemoveRoles { get; set; }

        [Required]
        [Column("CanEditRolePermissions")]
        public bool CanEditRolePermissions { get; set; }

        #endregion OwnProperties

        #region InverseProperties

        [IgnoreDataMember]
        [InverseProperty("Permissions")]
        public virtual ICollection<NoteUserPermissions> NoteUserPermissions { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Permissions")]
        public virtual ICollection<OrganizationNoteRolePermissions> OrganizationNoteRolePermissions { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Permissions")]
        public virtual ICollection<OrganizationNoteUserPermissions> OrganizationNoteUserPermissions { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Permissions")]
        public virtual ICollection<OrganizationRolePermissions> OrganizationRolePermissions { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Permissions")]
        public virtual ICollection<OrganizationUserPermissions> OrganizationUserPermissions { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Permissions")]
        public virtual ICollection<ProjectNoteRolePermissions> ProjectNoteRolePermissions { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Permissions")]
        public virtual ICollection<ProjectNoteUserPermissions> ProjectNoteUserPermissions { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Permissions")]
        public virtual ICollection<ProjectRolePermissions> ProjectRolePermissions { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Permissions")]
        public virtual ICollection<ProjectUserPermissions> ProjectUserPermissions { get; set; }

        #endregion InverseProperties
    }
}
