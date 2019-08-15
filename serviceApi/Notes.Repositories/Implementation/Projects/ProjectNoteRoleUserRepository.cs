using Notes.Data.Model.Projects;
using Notes.Data.Infrastructure;
using Notes.BusinessObjects.DataTransferObjects.Projects;

namespace Notes.Repositories.Implementation.Projects
{
    public class ProjectNoteRoleUserRepository : NotesRepository<ProjectNoteRoleUserDto, ProjectNoteRoleUser>
    {
        public ProjectNoteRoleUserRepository(IDbContext context) : base(context)
        {
        }
    }
}
