using Notes.Data.Model.Organizations;
using Notes.Data.Infrastructure;
using Notes.BusinessObjects.DataTransferObjects.Organizations;

namespace Notes.Repositories.Implementation.Organizations
{
    public class OrganizationStyleRepository : NotesRepository<OrganizationStyleDto, OrganizationStyle>
    {
        public OrganizationStyleRepository(IDbContext context) : base(context)
        {
        }
    }
}
