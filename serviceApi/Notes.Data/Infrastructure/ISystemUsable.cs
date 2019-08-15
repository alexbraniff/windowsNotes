using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Data.Infrastructure
{
    public interface ISystemUsable
    {
        [Required]
        [Column("IsSystemOnly")]
        bool IsSystemOnly { get; set; }
    }
}
