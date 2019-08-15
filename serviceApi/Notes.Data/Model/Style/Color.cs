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
    [DisplayName("Notes.Data.Model.Style.Color")]
    public class Color : IEntity
    {
        #region IEntity

        public int Id { get; set; }

        #endregion IEntity

        #region OwnProperties

        [Required]
        [Column("Name")]
        public string Name { get; set; }

        [Required]
        [Column("Hex")]
        public string Hex { get; set; }

        #endregion OwnProperties

        #region InverseProperties

        [IgnoreDataMember]
        [InverseProperty("Color")]
        public virtual ICollection<Border> Borders { get; set; }

        #region IStyle

        #region NoteStyle

        [IgnoreDataMember]
        [InverseProperty("PrimaryBackgroundColor")]
        public virtual ICollection<NoteStyle> PrimaryBackgroundColorNoteStyles { get; set; }

        [IgnoreDataMember]
        [InverseProperty("SecondaryBackgroundColor")]
        public virtual ICollection<NoteStyle> SecondaryBackgroundColorNoteStyles { get; set; }

        [IgnoreDataMember]
        [InverseProperty("AccentBackgroundColor")]
        public virtual ICollection<NoteStyle> AccentBackgroundColorNoteStyles { get; set; }

        [IgnoreDataMember]
        [InverseProperty("PrimaryFontColor")]
        public virtual ICollection<NoteStyle> PrimaryFontColorNoteStyles { get; set; }

        [IgnoreDataMember]
        [InverseProperty("SecondaryFontColor")]
        public virtual ICollection<NoteStyle> SecondaryFontColorNoteStyles { get; set; }

        [IgnoreDataMember]
        [InverseProperty("AccentFontColor")]
        public virtual ICollection<NoteStyle> AccentFontColorNoteStyles { get; set; }

        #endregion NoteStyle

        #region OrganizationStyle

        [IgnoreDataMember]
        [InverseProperty("PrimaryBackgroundColor")]
        public virtual ICollection<OrganizationStyle> PrimaryBackgroundColorOrganizationStyles { get; set; }

        [IgnoreDataMember]
        [InverseProperty("SecondaryBackgroundColor")]
        public virtual ICollection<OrganizationStyle> SecondaryBackgroundColorOrganizationStyles { get; set; }

        [IgnoreDataMember]
        [InverseProperty("AccentBackgroundColor")]
        public virtual ICollection<OrganizationStyle> AccentBackgroundColorOrganizationStyles { get; set; }

        [IgnoreDataMember]
        [InverseProperty("PrimaryFontColor")]
        public virtual ICollection<OrganizationStyle> PrimaryFontColorOrganizationStyles { get; set; }

        [IgnoreDataMember]
        [InverseProperty("SecondaryFontColor")]
        public virtual ICollection<OrganizationStyle> SecondaryFontColorOrganizationStyles { get; set; }

        [IgnoreDataMember]
        [InverseProperty("AccentFontColor")]
        public virtual ICollection<OrganizationStyle> AccentFontColorOrganizationStyles { get; set; }

        #endregion OrganizationStyle

        #region ProjectStyle

        [IgnoreDataMember]
        [InverseProperty("PrimaryBackgroundColor")]
        public virtual ICollection<ProjectStyle> PrimaryBackgroundColorProjectStyles { get; set; }

        [IgnoreDataMember]
        [InverseProperty("SecondaryBackgroundColor")]
        public virtual ICollection<ProjectStyle> SecondaryBackgroundColorProjectStyles { get; set; }

        [IgnoreDataMember]
        [InverseProperty("AccentBackgroundColor")]
        public virtual ICollection<ProjectStyle> AccentBackgroundColorProjectStyles { get; set; }

        [IgnoreDataMember]
        [InverseProperty("PrimaryFontColor")]
        public virtual ICollection<ProjectStyle> PrimaryFontColorProjectStyles { get; set; }

        [IgnoreDataMember]
        [InverseProperty("SecondaryFontColor")]
        public virtual ICollection<ProjectStyle> SecondaryFontColorProjectStyles { get; set; }

        [IgnoreDataMember]
        [InverseProperty("AccentFontColor")]
        public virtual ICollection<ProjectStyle> AccentFontColorProjectStyles { get; set; }

        #endregion ProjectStyle

        #region TagStyle

        [IgnoreDataMember]
        [InverseProperty("PrimaryBackgroundColor")]
        public virtual ICollection<TagStyle> PrimaryBackgroundColorTagStyles { get; set; }

        [IgnoreDataMember]
        [InverseProperty("SecondaryBackgroundColor")]
        public virtual ICollection<TagStyle> SecondaryBackgroundColorTagStyles { get; set; }

        [IgnoreDataMember]
        [InverseProperty("AccentBackgroundColor")]
        public virtual ICollection<TagStyle> AccentBackgroundColorTagStyles { get; set; }

        [IgnoreDataMember]
        [InverseProperty("PrimaryFontColor")]
        public virtual ICollection<TagStyle> PrimaryFontColorTagStyles { get; set; }

        [IgnoreDataMember]
        [InverseProperty("SecondaryFontColor")]
        public virtual ICollection<TagStyle> SecondaryFontColorTagStyles { get; set; }

        [IgnoreDataMember]
        [InverseProperty("AccentFontColor")]
        public virtual ICollection<TagStyle> AccentFontColorTagStyles { get; set; }

        #endregion TagStyle

        #region UserStyle

        [IgnoreDataMember]
        [InverseProperty("PrimaryBackgroundColor")]
        public virtual ICollection<UserStyle> PrimaryBackgroundColorUserStyles { get; set; }

        [IgnoreDataMember]
        [InverseProperty("SecondaryBackgroundColor")]
        public virtual ICollection<UserStyle> SecondaryBackgroundColorUserStyles { get; set; }

        [IgnoreDataMember]
        [InverseProperty("AccentBackgroundColor")]
        public virtual ICollection<UserStyle> AccentBackgroundColorUserStyles { get; set; }

        [IgnoreDataMember]
        [InverseProperty("PrimaryFontColor")]
        public virtual ICollection<UserStyle> PrimaryFontColorUserStyles { get; set; }

        [IgnoreDataMember]
        [InverseProperty("SecondaryFontColor")]
        public virtual ICollection<UserStyle> SecondaryFontColorUserStyles { get; set; }

        [IgnoreDataMember]
        [InverseProperty("AccentFontColor")]
        public virtual ICollection<UserStyle> AccentFontColorUserStyles { get; set; }

        #endregion UserStyle

        #endregion IStyle

        #endregion InverseProperties
    }
}
