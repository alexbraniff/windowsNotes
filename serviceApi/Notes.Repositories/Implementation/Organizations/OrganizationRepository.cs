using Notes.Data.Model.Organizations;
using Notes.Data.Infrastructure;
using Notes.BusinessObjects.DataTransferObjects.Organizations;

namespace Notes.Repositories.Implementation.Organizations
{
    public class OrganizationRepository : NotesRepository<OrganizationDto, Organization>
    {
        public OrganizationRepository(IDbContext context) : base(context)
        {
        }
    }
}
