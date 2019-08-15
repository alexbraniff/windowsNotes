using Notes.Data.Infrastructure;
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

namespace Notes.Data.Model.Organizations
{
    [DisplayName("Notes.Data.Model.Organizations.OrganizationUser")]
    public class OrganizationUser : IEntity, IRemovable
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
        [ForeignKey("User")]
        [Column("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }

        #endregion OwnProperties

        #region InverseProperties

        [IgnoreDataMember]
        [InverseProperty("OrganizationUser")]
        public virtual ICollection<OrganizationUserPermissions> Permissions { get; set; }

        #endregion InverseProperties
    }
}
