using Notes.Data.Model.Audit;
using System;
using System.Collections.Generic;
using System.Text;
using Notes.Data.Infrastructure;
using Notes.BusinessObjects.DataTransferObjects.Audit;

namespace Notes.Repositories.Implementation.Audit
{
    public class AuditDeleteRepository : NotesRepository<AuditDeleteDto, AuditDelete>
    {
        public AuditDeleteRepository(IDbContext context) : base(context)
        {
        }
    }
}
