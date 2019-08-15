using Notes.Data.Model.Projects;
using Notes.Data.Infrastructure;
using Notes.BusinessObjects.DataTransferObjects.Projects;

namespace Notes.Repositories.Implementation.Projects
{
    public class ProjectNoteRolePermissionsRepository : NotesRepository<ProjectNoteRolePermissionsDto, ProjectNoteRolePermissions>
    {
        public ProjectNoteRolePermissionsRepository(IDbContext context) : base(context)
        {
        }
    }
}
