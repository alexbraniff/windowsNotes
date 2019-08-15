using Notes.Data.Model.Organizations;
using Notes.Data.Infrastructure;
using Notes.BusinessObjects.DataTransferObjects.Organizations;

namespace Notes.Repositories.Implementation.Organizations
{
    public class OrganizationNoteUserRepository : NotesRepository<OrganizationNoteUserDto, OrganizationNoteUser>
    {
        public OrganizationNoteUserRepository(IDbContext context) : base(context)
        {
        }
    }
}
