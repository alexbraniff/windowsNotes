using Notes.Data.Model.Projects;
using Notes.Data.Infrastructure;
using Notes.BusinessObjects.DataTransferObjects.Projects;

namespace Notes.Repositories.Implementation.Projects
{
    public class ProjectRolePermissionsRepository : NotesRepository<ProjectRolePermissionsDto, ProjectRolePermissions>
    {
        public ProjectRolePermissionsRepository(IDbContext context) : base(context)
        {
        }
    }
}
