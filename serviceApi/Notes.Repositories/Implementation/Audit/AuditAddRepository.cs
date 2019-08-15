using Notes.Data.Model.Audit;
using Notes.Data.Infrastructure;
using Notes.BusinessObjects.DataTransferObjects.Audit;

namespace Notes.Repositories.Implementation.Audit
{
    public class AuditAddRepository : NotesRepository<AuditAddDto, AuditAdd>
    {
        public AuditAddRepository(IDbContext context) : base(context)
        {
        }
    }
}
