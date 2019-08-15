using Notes.Data.Model.Organizations;
using Notes.Data.Infrastructure;
using Notes.BusinessObjects.DataTransferObjects.Organizations;

namespace Notes.Repositories.Implementation.Organizations
{
    public class OrganizationUserPermissionsRepository : NotesRepository<OrganizationUserPermissionsDto, OrganizationUserPermissions>
    {
        public OrganizationUserPermissionsRepository(IDbContext context) : base(context)
        {
        }
    }
}
