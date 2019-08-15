using Notes.Data.Model.Projects;
using Notes.Data.Infrastructure;
using Notes.BusinessObjects.DataTransferObjects.Projects;

namespace Notes.Repositories.Implementation.Projects
{
    public class ProjectNoteUserPermissionsRepository : NotesRepository<ProjectNoteUserPermissionsDto, ProjectNoteUserPermissions>
    {
        public ProjectNoteUserPermissionsRepository(IDbContext context) : base(context)
        {
        }
    }
}
