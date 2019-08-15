using Notes.Data.Model.Projects;
using Notes.Data.Infrastructure;
using Notes.BusinessObjects.DataTransferObjects.Projects;

namespace Notes.Repositories.Implementation.Projects
{
    public class ProjectRoleUserRepository : NotesRepository<ProjectRoleUserDto, ProjectRoleUser>
    {
        public ProjectRoleUserRepository(IDbContext context) : base(context)
        {
        }
    }
}
