using Notes.Data.Model.Organizations;
using Notes.Data.Infrastructure;
using Notes.BusinessObjects.DataTransferObjects.Organizations;

namespace Notes.Repositories.Implementation.Organizations
{
    public class OrganizationRoleUserRepository : NotesRepository<OrganizationRoleUserDto, OrganizationRoleUser>
    {
        public OrganizationRoleUserRepository(IDbContext context) : base(context)
        {
        }
    }
}
