using Notes.Data.Model.Projects;
using Notes.Data.Infrastructure;
using Notes.BusinessObjects.DataTransferObjects.Projects;

namespace Notes.Repositories.Implementation.Projects
{
    public class ProjectRepository : NotesRepository<ProjectDto, Project>
    {
        public ProjectRepository(IDbContext context) : base(context)
        {
        }
    }
}
