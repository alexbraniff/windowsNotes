using Notes.Data.Model.Notes;
using Notes.Data.Infrastructure;
using Notes.BusinessObjects.DataTransferObjects.Notes;

namespace Notes.Repositories.Implementation.Notes
{
    public class NoteUserPermissionsRepository : NotesRepository<NoteUserPermissionsDto, NoteUserPermissions>
    {
        public NoteUserPermissionsRepository(IDbContext context) : base(context)
        {
        }
    }
}
