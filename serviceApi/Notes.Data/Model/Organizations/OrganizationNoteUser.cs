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
    [DisplayName("Notes.Data.Model.Organizations.OrganizationNoteUser")]
    public class OrganizationNoteUser : IEntity, IRemovable
    {
        #region IEntity

        public int Id { get; set; }

        #endregion IEntity

        #region IRemovable

        public bool IsRemoved { get; set; }

        #endregion IRemovable

        #region OwnProperties

        [Required]
        [Column("OrganizationNoteId")]
        [ForeignKey("OrganizationNote")]
        public int OrganizationNoteId { get; set; }
        public OrganizationNote OrganizationNote { get; set; }

        [Required]
        [Column("UserId")]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        #endregion OwnProperties

        #region InverseProperties

        [IgnoreDataMember]
        [InverseProperty("OrganizationNoteUser")]
        public virtual ICollection<OrganizationNoteUserPermissions> Permissions { get; set; }

        #endregion InverseProperties
    }
}
