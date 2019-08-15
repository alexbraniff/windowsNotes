using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Data.Infrastructure
{
    public interface IEntityTree<T> : IEntity where T : IEntityTree<T>
    {
        [Column("ParentId")]
        [ForeignKey("Parent")]
        int? ParentId { get; set; }
        T Parent { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Parent")]
        ICollection<T> Children { get; set; }
    }
}
