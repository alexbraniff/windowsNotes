using Notes.Data.Model.Projects;
using Notes.Data.Infrastructure;
using Notes.BusinessObjects.DataTransferObjects.Projects;

namespace Notes.Repositories.Implementation.Projects
{
    public class ProjectUserRepository : NotesRepository<ProjectUserDto, ProjectUser>
    {
        public ProjectUserRepository(IDbContext context) : base(context)
        {
        }
    }
}
