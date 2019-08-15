using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Data.Infrastructure
{
    public interface ILookup<T> : IEntity where T : struct, IConvertible
    {
        [Required]
        [Column("Name")]
        string Name { get; set; }
    }
}
