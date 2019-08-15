using Notes.Data.Model.Projects;
using Notes.Data.Infrastructure;
using Notes.BusinessObjects.DataTransferObjects.Projects;

namespace Notes.Repositories.Implementation.Projects
{
    public class ProjectNoteRoleRepository : NotesRepository<ProjectNoteRoleDto, ProjectNoteRole>
    {
        public ProjectNoteRoleRepository(IDbContext context) : base(context)
        {
        }
    }
}
