using Notes.Data.Model.Notes;
using System;
using Notes.Data.Infrastructure;
using Ninject;
using Notes.BusinessObjects.DataTransferObjects.Notes;

namespace Notes.Repositories.Implementation.Notes
{
    public class NoteRepository : NotesRepository<NoteDto, Note>
    {
        [Inject]
        public NoteRepository(IDbContext context) : base(context)
        {
        }
    }
}
