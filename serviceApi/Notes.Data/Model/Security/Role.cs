using Notes.Data.Infrastructure;
using Notes.Data.Model.Organizations;
using Notes.Data.Model.Projects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace Notes.Data.Model.Security
{
    [DisplayName("Notes.Data.Model.Security.Role")]
    public class Role : IEntityTree<Role>, IRemovable, ISystemUsable
    {
        #region IEntity

        public int Id { get; set; }

        #endregion IEntity

        #region IEntityTree
        
        public int? ParentId { get; set; }
        public Role Parent { get; set; }
        
        public virtual ICollection<Role> Children { get; set; }

        #endregion IEntityTree

        #region IRemovable
        
        public bool IsRemoved { get; set; }

        #endregion IRemovable

        #region ISystemUsable
        
        [Required]
        [Column("IsSystemOnly")]
        public bool IsSystemOnly { get; set; }

        #endregion ISystemUsable

        #region OwnProperties

        [Required]
        [Column("Name")]
        [Index(IsUnique = true)]
        [MaxLength(255)]
        public string Name { get; set; }

        #endregion OwnProperties

        #region InverseProperties

        [IgnoreDataMember]
        [InverseProperty("Role")]
        public virtual ICollection<OrganizationNoteRole> OrganizationNotes { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Role")]
        public virtual ICollection<OrganizationRole> Organizations { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Role")]
        public virtual ICollection<ProjectNoteRole> ProjectNotes { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Role")]
        public virtual ICollection<ProjectRole> Projects { get; set; }

        #endregion InverseProperties
    }
}
