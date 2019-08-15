using Notes.Data.Model.Projects;
using Notes.Data.Infrastructure;
using Notes.BusinessObjects.DataTransferObjects.Projects;

namespace Notes.Repositories.Implementation.Projects
{
    public class ProjectNoteUserRepository : NotesRepository<ProjectNoteUserDto, ProjectNoteUser>
    {
        public ProjectNoteUserRepository(IDbContext context) : base(context)
        {
        }
    }
}
