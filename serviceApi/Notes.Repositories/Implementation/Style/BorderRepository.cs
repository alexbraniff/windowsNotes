using Notes.Data.Model.Style;
using Notes.Data.Infrastructure;
using Notes.BusinessObjects.DataTransferObjects.Style;

namespace Notes.Repositories.Implementation.Style
{
    public class BorderRepository : NotesRepository<BorderDto, Border>
    {
        public BorderRepository(IDbContext context) : base(context)
        {
        }
    }
}
