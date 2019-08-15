using Notes.Data.Infrastructure;
using Notes.Data.Model.Audit;
using Notes.Data.Model.Notes;
using Notes.Data.Model.Organizations;
using Notes.Data.Model.Projects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace Notes.Data.Model.Users
{
    [DisplayName("Notes.Data.Model.Users.User")]
    public class User : IEntity, IRemovable, ISystemUsable, IStylable<UserStyle>
    {
        #region IEntity

        public int Id { get; set; }

        #endregion IEntity

        #region IRemovable
        
        public bool IsRemoved { get; set; }

        #endregion IRemovable

        #region ISystemUsable

        public bool IsSystemOnly { get; set; }

        #endregion ISystemUsable

        #region IStylable

        public int? StyleId { get; set; }
        public UserStyle Style { get; set; }

        #endregion IStylable

        #region OwnProperties

        [Required]
        [Column("Name")]
        [MaxLength(255)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        [Required]
        [Column("PasswordHash")]
        public string PasswordHash { get; set; }

        [Required]
        [Column("PasswordSalt")]
        public string PasswordSalt { get; set; }

        [NotMapped]
        public string Token { get; set; }

        #endregion OwnProperties

        #region InverseProperties

        [IgnoreDataMember]
        [InverseProperty("User")]
        public virtual ICollection<NoteUser> Notes { get; set; }

        [IgnoreDataMember]
        [InverseProperty("User")]
        public virtual ICollection<OrganizationNoteRoleUser> OrganizationNoteRoles { get; set; }

        [IgnoreDataMember]
        [InverseProperty("User")]
        public virtual ICollection<OrganizationNoteUser> OrganizationNotes { get; set; }

        [IgnoreDataMember]
        [InverseProperty("User")]
        public virtual ICollection<OrganizationRoleUser> OrganizationRoles { get; set; }

        [IgnoreDataMember]
        [InverseProperty("User")]
        public virtual ICollection<OrganizationUser> Organizations { get; set; }

        [IgnoreDataMember]
        [InverseProperty("User")]
        public virtual ICollection<ProjectNoteRoleUser> ProjectNoteRoles { get; set; }

        [IgnoreDataMember]
        [InverseProperty("User")]
        public virtual ICollection<ProjectNoteUser> ProjectNotes { get; set; }

        [IgnoreDataMember]
        [InverseProperty("User")]
        public virtual ICollection<ProjectRoleUser> ProjectRoles { get; set; }

        [IgnoreDataMember]
        [InverseProperty("User")]
        public virtual ICollection<ProjectUser> Projects { get; set; }

        [IgnoreDataMember]
        [InverseProperty("User")]
        public virtual ICollection<UserTag> Tags { get; set; }

        #region Audit

        [IgnoreDataMember]
        [InverseProperty("User")]
        public virtual ICollection<AuditAdd> AddHistory { get; set; }

        [IgnoreDataMember]
        [InverseProperty("User")]
        public virtual ICollection<AuditUpdate> UpdateHistory { get; set; }

        [IgnoreDataMember]
        [InverseProperty("User")]
        public virtual ICollection<AuditDelete> DeleteHistory { get; set; }

        #endregion Audit

        #endregion InverseProperties
    }
}
