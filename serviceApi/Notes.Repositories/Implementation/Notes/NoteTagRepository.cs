using Notes.Data.Model.Notes;
using Notes.Data.Infrastructure;
using Notes.BusinessObjects.DataTransferObjects.Notes;

namespace Notes.Repositories.Implementation.Notes
{
    public class NoteTagRepository : NotesRepository<NoteTagDto, NoteTag>
    {
        public NoteTagRepository(IDbContext context) : base(context)
        {
        }
    }
}
