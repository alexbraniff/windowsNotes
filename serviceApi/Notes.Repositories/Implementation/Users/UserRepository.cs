using Notes.Data.Model.Users;
using Notes.Data.Infrastructure;
using Notes.BusinessObjects.DataTransferObjects.Users;

namespace Notes.Repositories.Implementation.Users
{
    public class UserRepository : NotesRepository<UserDto, User>
    {
        public UserRepository(IDbContext context) : base(context)
        {
        }
    }
}
