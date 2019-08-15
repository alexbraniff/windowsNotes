using Notes.Data.Model.Projects;
using Notes.Data.Infrastructure;
using Notes.BusinessObjects.DataTransferObjects.Projects;

namespace Notes.Repositories.Implementation.Projects
{
    public class ProjectTagRepository : NotesRepository<ProjectTagDto, ProjectTag>
    {
        public ProjectTagRepository(IDbContext context) : base(context)
        {
        }
    }
}
