using Notes.Data.Model.Style;
using Notes.Data.Infrastructure;
using Notes.BusinessObjects.DataTransferObjects.Style;

namespace Notes.Repositories.Implementation.Style
{
    public class ColorRepository : NotesRepository<ColorDto, Color>
    {
        public ColorRepository(IDbContext context) : base(context)
        {
        }
    }
}
