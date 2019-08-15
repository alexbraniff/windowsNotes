using Notes.Data.Model.Organizations;
using Notes.Data.Infrastructure;
using Notes.BusinessObjects.DataTransferObjects.Organizations;

namespace Notes.Repositories.Implementation.Organizations
{
    public class OrganizationProjectRepository : NotesRepository<OrganizationProjectDto, OrganizationProject>
    {
        public OrganizationProjectRepository(IDbContext context) : base(context)
        {
        }
    }
}
