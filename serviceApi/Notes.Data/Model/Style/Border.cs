using Notes.Data.Infrastructure;
using Notes.Data.Model.Notes;
using Notes.Data.Model.Organizations;
using Notes.Data.Model.Projects;
using Notes.Data.Model.Tags;
using Notes.Data.Model.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Data.Model.Style
{
    [DisplayName("Notes.Data.Model.Style.Border")]
    public class Border : IEntity
    {
        #region IEntity

        public int Id { get; set; }

        #endregion IEntity

        #region OwnProperties

        [Column("ColorId")]
        [ForeignKey("Color")]
        public int? ColorId { get; set; }
        public Color Color { get; set; }

        [Column("BorderTypeId")]
        [ForeignKey("BorderType")]
        public int? BorderTypeId { get; set; }
        public BorderType BorderType { get; set; }

        [Column("Width")]
        public double Width { get; set; }

        [Column("CornerRadius")]
        public double CornerRadius { get; set; }

        #endregion OwnProperties

        #region InverseProperties

        #region IStyle

        #region NoteStyle

        [IgnoreDataMember]
        [InverseProperty("PrimaryBorder")]
        public virtual ICollection<NoteStyle> PrimaryNoteBorders { get; set; }

        [IgnoreDataMember]
        [InverseProperty("SecondaryBorder")]
        public virtual ICollection<NoteStyle> SecondaryNoteBorders { get; set; }

        [IgnoreDataMember]
        [InverseProperty("AccentBorder")]
        public virtual ICollection<NoteStyle> AccentNoteBorders { get; set; }

        #endregion NoteStyle

        #region OrganizationStyle

        [IgnoreDataMember]
        [InverseProperty("PrimaryBorder")]
        public virtual ICollection<OrganizationStyle> PrimaryOrganizationBorders { get; set; }

        [IgnoreDataMember]
        [InverseProperty("SecondaryBorder")]
        public virtual ICollection<OrganizationStyle> SecondaryOrganizationBorders { get; set; }

        [IgnoreDataMember]
        [InverseProperty("AccentBorder")]
        public virtual ICollection<OrganizationStyle> AccentOrganizationBorders { get; set; }

        #endregion OrganizationStyle

        #region ProjectStyle

        [IgnoreDataMember]
        [InverseProperty("PrimaryBorder")]
        public virtual ICollection<ProjectStyle> PrimaryProjectBorders { get; set; }

        [IgnoreDataMember]
        [InverseProperty("SecondaryBorder")]
        public virtual ICollection<ProjectStyle> SecondaryProjectBorders { get; set; }

        [IgnoreDataMember]
        [InverseProperty("AccentBorder")]
        public virtual ICollection<ProjectStyle> AccentProjectBorders { get; set; }

        #endregion ProjectStyle

        #region TagStyle

        [IgnoreDataMember]
        [InverseProperty("PrimaryBorder")]
        public virtual ICollection<TagStyle> PrimaryTagBorders { get; set; }

        [IgnoreDataMember]
        [InverseProperty("SecondaryBorder")]
        public virtual ICollection<TagStyle> SecondaryTagBorders { get; set; }

        [IgnoreDataMember]
        [InverseProperty("AccentBorder")]
        public virtual ICollection<TagStyle> AccentTagBorders { get; set; }

        #endregion TagStyle

        #region UserStyle

        [IgnoreDataMember]
        [InverseProperty("PrimaryBorder")]
        public virtual ICollection<UserStyle> PrimaryUserBorders { get; set; }

        [IgnoreDataMember]
        [InverseProperty("SecondaryBorder")]
        public virtual ICollection<UserStyle> SecondaryUserBorders { get; set; }

        [IgnoreDataMember]
        [InverseProperty("AccentBorder")]
        public virtual ICollection<UserStyle> AccentUserBorders { get; set; }

        #endregion UserStyle

        #endregion IStyle

        #endregion InverseProperties
    }
}
