using Notes.Data.Model.Tags;
using Notes.Data.Infrastructure;
using Notes.BusinessObjects.DataTransferObjects.Tags;

namespace Notes.Repositories.Implementation.Tags
{
    public class TagRepository : NotesRepository<TagDto, Tag>
    {
        public TagRepository(IDbContext context) : base(context)
        {
        }
    }
}
