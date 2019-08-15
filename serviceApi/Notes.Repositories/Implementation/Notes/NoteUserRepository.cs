using Notes.Data.Model.Notes;
using Notes.Data.Infrastructure;
using Notes.BusinessObjects.DataTransferObjects.Notes;

namespace Notes.Repositories.Implementation.Notes
{
    public class NoteUserRepository : NotesRepository<NoteUserDto, NoteUser>
    {
        public NoteUserRepository(IDbContext context) : base(context)
        {
        }
    }
}
