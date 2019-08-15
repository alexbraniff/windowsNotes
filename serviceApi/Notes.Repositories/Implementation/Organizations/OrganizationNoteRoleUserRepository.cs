using Notes.Data.Model.Organizations;
using Notes.Data.Infrastructure;
using Notes.BusinessObjects.DataTransferObjects.Organizations;

namespace Notes.Repositories.Implementation.Organizations
{
    public class OrganizationNoteRoleUserRepository : NotesRepository<OrganizationNoteRoleUserDto, OrganizationNoteRoleUser>
    {
        public OrganizationNoteRoleUserRepository(IDbContext context) : base(context)
        {
        }
    }
}
