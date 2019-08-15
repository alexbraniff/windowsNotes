using Notes.Data.Model.Organizations;
using Notes.Data.Infrastructure;
using Notes.BusinessObjects.DataTransferObjects.Organizations;

namespace Notes.Repositories.Implementation.Organizations
{
    public class OrganizationNoteRolePermissionsRepository : NotesRepository<OrganizationNoteRolePermissionsDto, OrganizationNoteRolePermissions>
    {
        public OrganizationNoteRolePermissionsRepository(IDbContext context) : base(context)
        {
        }
    }
}
