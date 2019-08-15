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
    [DisplayName("Notes.Data.Model.Organizations.OrganizationNoteRoleUser")]
    public class OrganizationNoteRoleUser : IEntity, IRemovable
    {
        #region IEntity

        public int Id { get; set; }

        #endregion IEntity

        #region IRemovable

        public bool IsRemoved { get; set; }

        #endregion IRemovable

        #region OwnProperties

        [Required]
        [Column("OrganizationNoteRoleId")]
        [ForeignKey("OrganizationNoteRole")]
        public int OrganizationNoteRoleId { get; set; }
        public OrganizationNoteRole OrganizationNoteRole { get; set; }

        [Required]
        [Column("UserId")]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        #endregion OwnProperties

        #region InverseProperties

        #endregion InverseProperties
    }
}
