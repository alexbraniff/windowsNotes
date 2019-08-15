using Notes.Data.Model.Users;
using Notes.Data.Infrastructure;
using Notes.BusinessObjects.DataTransferObjects.Users;

namespace Notes.Repositories.Implementation.Users
{
    public class UserTagRepository : NotesRepository<UserTagDto, UserTag>
    {
        public UserTagRepository(IDbContext context) : base(context)
        {
        }
    }
}
