using Notes.Data.Model.Audit;
using Notes.Data.Infrastructure;
using Notes.BusinessObjects.DataTransferObjects.Audit;

namespace Notes.Repositories.Implementation.Audit
{
    public class AuditUpdateRepository : NotesRepository<AuditUpdateDto, AuditUpdate>
    {
        public AuditUpdateRepository(IDbContext context) : base(context)
        {
        }
    }
}
