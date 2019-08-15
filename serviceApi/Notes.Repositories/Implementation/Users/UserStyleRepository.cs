using Notes.Data.Model.Users;
using Notes.Data.Infrastructure;
using Notes.BusinessObjects.DataTransferObjects.Users;

namespace Notes.Repositories.Implementation.Users
{
    public class UserStyleRepository : NotesRepository<UserStyleDto, UserStyle>
    {
        public UserStyleRepository(IDbContext context) : base(context)
        {
        }
    }
}
