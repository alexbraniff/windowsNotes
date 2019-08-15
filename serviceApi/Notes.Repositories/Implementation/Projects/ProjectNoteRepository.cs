using Notes.Data.Model.Projects;
using Notes.Data.Infrastructure;
using Notes.BusinessObjects.DataTransferObjects.Projects;

namespace Notes.Repositories.Implementation.Projects
{
    public class ProjectNoteRepository : NotesRepository<ProjectNoteDto, ProjectNote>
    {
        public ProjectNoteRepository(IDbContext context) : base(context)
        {
        }
    }
}
