using Notes.Data.Model.Organizations;
using Notes.Data.Infrastructure;
using Notes.BusinessObjects.DataTransferObjects.Organizations;

namespace Notes.Repositories.Implementation.Organizations
{
    public class OrganizationUserRepository : NotesRepository<OrganizationUserDto, OrganizationUser>
    {
        public OrganizationUserRepository(IDbContext context) : base(context)
        {
        }
    }
}
