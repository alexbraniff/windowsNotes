using Notes.Data.Model.Organizations;
using Notes.Data.Infrastructure;
using Notes.BusinessObjects.DataTransferObjects.Organizations;

namespace Notes.Repositories.Implementation.Organizations
{
    public class OrganizationRolePermissionsRepository : NotesRepository<OrganizationRolePermissionsDto, OrganizationRolePermissions>
    {
        public OrganizationRolePermissionsRepository(IDbContext context) : base(context)
        {
        }
    }
}
