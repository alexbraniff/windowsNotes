using Notes.Data.Infrastructure;
using Notes.Data.Model.Style;
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
    [DisplayName("Notes.Data.Model.Projects.ProjectStyle")]
    public class ProjectStyle : IEntity, IRemovable, IStyle
    {
        #region IEntity

        public int Id { get; set; }

        #endregion IEntity

        #region IRemovable

        public bool IsRemoved { get; set; }

        #endregion IRemovable

        #region IStyle

        public int? PrimaryBackgroundColorId { get; set; }
        public Color PrimaryBackgroundColor { get; set; }

        public int? SecondaryBackgroundColorId { get; set; }
        public Color SecondaryBackgroundColor { get; set; }

        public int? AccentBackgroundColorId { get; set; }
        public Color AccentBackgroundColor { get; set; }

        public int? PrimaryFontColorId { get; set; }
        public Color PrimaryFontColor { get; set; }

        public int? SecondaryFontColorId { get; set; }
        public Color SecondaryFontColor { get; set; }

        public int? AccentFontColorId { get; set; }
        public Color AccentFontColor { get; set; }

        public int? PrimaryBorderId { get; set; }
        public Border PrimaryBorder { get; set; }

        public int? SecondaryBorderId { get; set; }
        public Border SecondaryBorder { get; set; }

        public int? AccentBorderId { get; set; }
        public Border AccentBorder { get; set; }

        #endregion IStyle

        #region OwnProperties

        #endregion OwnProperties

        #region InverseProperties

        [IgnoreDataMember]
        [InverseProperty("Style")]
        public virtual ICollection<Project> Projects { get; set; }

        #endregion InverseProperties
    }
}
