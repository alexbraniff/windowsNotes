using Notes.Data.Model.Projects;
using Notes.Data.Infrastructure;
using Notes.BusinessObjects.DataTransferObjects.Projects;

namespace Notes.Repositories.Implementation.Projects
{
    public class ProjectRoleRepository : NotesRepository<ProjectRoleDto, ProjectRole>
    {
        public ProjectRoleRepository(IDbContext context) : base(context)
        {
        }
    }
}
