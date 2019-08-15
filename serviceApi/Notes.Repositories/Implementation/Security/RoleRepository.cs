using Notes.Data.Model.Security;
using Notes.Data.Infrastructure;
using Notes.BusinessObjects.DataTransferObjects.Security;

namespace Notes.Repositories.Implementation.Security
{
    public class RoleRepository : NotesRepository<RoleDto, Role>
    {
        public RoleRepository(IDbContext context) : base(context)
        {
        }
    }
}
