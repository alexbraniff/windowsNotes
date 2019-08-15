using Notes.Data.Model.Organizations;
using Notes.Data.Infrastructure;
using Notes.BusinessObjects.DataTransferObjects.Organizations;

namespace Notes.Repositories.Implementation.Organizations
{
    public class OrganizationRoleRepository : NotesRepository<OrganizationRoleDto, OrganizationRole>
    {
        public OrganizationRoleRepository(IDbContext context) : base(context)
        {
        }
    }
}
