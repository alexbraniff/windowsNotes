using Notes.Data.Model.Organizations;
using Notes.Data.Infrastructure;
using Notes.BusinessObjects.DataTransferObjects.Organizations;

namespace Notes.Repositories.Implementation.Organizations
{
    public class OrganizationNoteRepository : NotesRepository<OrganizationNoteDto, OrganizationNote>
    {
        public OrganizationNoteRepository(IDbContext context) : base(context)
        {
        }
    }
}
