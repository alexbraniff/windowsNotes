using Notes.Data.Infrastructure;
using Notes.Data.Model.Tags;
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
    [DisplayName("Notes.Data.Model.Organizations.OrganizationTag")]
    public class OrganizationTag : IEntity, IRemovable
    {
        #region IEntity

        public int Id { get; set; }

        #endregion IEntity

        #region IRemovable

        [Required]
        [Column("IsRemoved")]
        public bool IsRemoved { get; set; }

        #endregion IRemovable

        #region OwnProperties

        [Required]
        [ForeignKey("Organization")]
        [Column("OrganizationId")]
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }

        [Required]
        [ForeignKey("Tag")]
        [Column("TagId")]
        public int TagId { get; set; }
        public Tag Tag { get; set; }

        #endregion OwnProperties

        #region InverseProperties

        #endregion InverseProperties
    }
}
