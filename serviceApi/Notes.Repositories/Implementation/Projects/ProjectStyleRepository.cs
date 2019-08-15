using Notes.Data.Model.Projects;
using Notes.Data.Infrastructure;
using Notes.BusinessObjects.DataTransferObjects.Projects;

namespace Notes.Repositories.Implementation.Projects
{
    public class ProjectStyleRepository : NotesRepository<ProjectStyleDto, ProjectStyle>
    {
        public ProjectStyleRepository(IDbContext context) : base(context)
        {
        }
    }
}
