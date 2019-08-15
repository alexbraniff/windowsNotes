using Notes.Data.Model.Organizations;
using Notes.Data.Infrastructure;
using Notes.BusinessObjects.DataTransferObjects.Organizations;

namespace Notes.Repositories.Implementation.Organizations
{
    public class OrganizationNoteRoleRepository : NotesRepository<OrganizationNoteRoleDto, OrganizationNoteRole>
    {
        public OrganizationNoteRoleRepository(IDbContext context) : base(context)
        {
        }
    }
}
