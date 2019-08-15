using Notes.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Data.Model.Style
{
    [DisplayName("Notes.Data.Model.Style.BorderType")]
    public class BorderType : ILookup<EBorderType>
    {
        #region ILookup

        #region IEntity

        public int Id { get; set; }

        #endregion IEntity

        public string Name { get; set; }

        #endregion ILookup

        #region InverseProperties

        [IgnoreDataMember]
        [InverseProperty("BorderType")]
        public virtual ICollection<Border> Borders { get; set; }

        #endregion InverseProperties
    }
}
