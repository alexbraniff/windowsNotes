using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace Notes.Data.Infrastructure
{
    public interface IRemovable
    {
        [Required]
        [Column("IsRemoved")]
        bool IsRemoved { get; set; }
    }
}
