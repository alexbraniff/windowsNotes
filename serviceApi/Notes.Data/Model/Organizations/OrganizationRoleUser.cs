using Notes.Data.Infrastructure;
using Notes.Data.Model.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace Notes.Data.Model.Organizations
{
    [DisplayName("Notes.Data.Model.Organizations.OrganizationRoleUser")]
    public class OrganizationRoleUser : IEntity, IRemovable
    {
        #region IEntity

        public int Id { get; set; }

        #endregion IEntity

        #region IRemovable
        
        public bool IsRemoved { get; set; }

        #endregion IRemovable

        #region OwnProperties

        [Required]
        [ForeignKey("OrganizationRole")]
        [Column("OrganizationRoleId")]
        public int OrganizationRoleId { get; set; }
        public OrganizationRole OrganizationRole { get; set; }
        
        [Required]
        [ForeignKey("User")]
        [Column("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }

        #endregion OwnProperties

        #region InverseProperties

        #endregion InverseProperties
    }
}
