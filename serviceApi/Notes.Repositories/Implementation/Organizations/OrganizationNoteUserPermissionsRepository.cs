using Notes.Data.Model.Organizations;
using Notes.Data.Infrastructure;
using Notes.BusinessObjects.DataTransferObjects.Organizations;

namespace Notes.Repositories.Implementation.Organizations
{
    public class OrganizationNoteUserPermissionsRepository : NotesRepository<OrganizationNoteUserPermissionsDto, OrganizationNoteUserPermissions>
    {
        public OrganizationNoteUserPermissionsRepository(IDbContext context) : base(context)
        {
        }
    }
}
