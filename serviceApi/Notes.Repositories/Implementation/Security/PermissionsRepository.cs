using Notes.Data.Model.Security;
using Notes.Data.Infrastructure;
using Notes.BusinessObjects.DataTransferObjects.Security;

namespace Notes.Repositories.Implementation.Security
{
    public class PermissionsRepository : NotesRepository<PermissionsDto, Permissions>
    {
        public PermissionsRepository(IDbContext context) : base(context)
        {
        }
    }
}
