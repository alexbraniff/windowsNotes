using Notes.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace Notes.Data.Model.Organizations
{
    [DisplayName("Notes.Data.Model.Organizations.Organization")]
    public class Organization : IEntity, IRemovable, ISystemUsable, IStylable<OrganizationStyle>
    {
        #region IEntity

        public int Id { get; set; }

        #endregion IEntity

        #region IRemovable

        public bool IsRemoved { get; set; }

        #endregion IRemovable

        #region ISystemUsable

        [Required]
        [Column("IsSystemOnly")]
        public bool IsSystemOnly { get; set; }

        #endregion ISystemUsable

        #region IStylable

        public int? StyleId { get; set; }
        public OrganizationStyle Style { get; set; }

        #endregion IStylable

        #region OwnProperties

        [Required]
        [Column("Name")]
        public string Name { get; set; }

        #endregion OwnProperties

        #region InverseProperties

        [IgnoreDataMember]
        [InverseProperty("Organization")]
        public virtual ICollection<OrganizationNote> Notes { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Organization")]
        public virtual ICollection<OrganizationProject> Projects { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Organization")]
        public virtual ICollection<OrganizationRole> Roles { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Organization")]
        public virtual ICollection<OrganizationTag> Tags { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Organization")]
        public virtual ICollection<OrganizationUser> Users { get; set; }

        #endregion InverseProperties
    }
}
