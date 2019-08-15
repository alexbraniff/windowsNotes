using Notes.Data.Model.Tags;
using Notes.Data.Infrastructure;
using Notes.BusinessObjects.DataTransferObjects.Tags;

namespace Notes.Repositories.Implementation.Tags
{
    public class TagStyleRepository : NotesRepository<TagStyleDto, TagStyle>
    {
        public TagStyleRepository(IDbContext context) : base(context)
        {
        }
    }
}
