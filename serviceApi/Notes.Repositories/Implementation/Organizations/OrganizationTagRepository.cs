using Notes.Data.Model.Organizations;
using Notes.Data.Infrastructure;
using Notes.BusinessObjects.DataTransferObjects.Organizations;

namespace Notes.Repositories.Implementation.Organizations
{
    public class OrganizationTagRepository : NotesRepository<OrganizationTagDto, OrganizationTag>
    {
        public OrganizationTagRepository(IDbContext context) : base(context)
        {
        }
    }
}
