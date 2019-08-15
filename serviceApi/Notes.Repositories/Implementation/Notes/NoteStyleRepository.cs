using Notes.Data.Model.Notes;
using Notes.Data.Infrastructure;
using Notes.BusinessObjects.DataTransferObjects.Notes;

namespace Notes.Repositories.Implementation.Notes
{
    public class NoteStyleRepository : NotesRepository<NoteStyleDto, NoteStyle>
    {
        public NoteStyleRepository(IDbContext context) : base(context)
        {
        }
    }
}
