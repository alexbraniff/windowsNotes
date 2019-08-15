using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Data.Infrastructure
{
    public interface IStylable<T> where T : IStyle
    {
        [ForeignKey("Style")]
        [Column("StyleId")]
        int? StyleId { get; set; }
        T Style { get; set; }
    }
}
