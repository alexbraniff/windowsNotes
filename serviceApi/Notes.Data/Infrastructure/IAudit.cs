using Notes.Data.Model.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Notes.Data.Infrastructure
{
    public interface IAudit
    {
        DateTime Timestamp { get; set; }
        int UserId { get; set; }
        User User { get; set; }
        string Entity { get; set; }
        int EntityId { get; set; }
    }
}
