using Notes.Data.Model.Style;
using Notes.Data.Infrastructure;
using Notes.BusinessObjects.DataTransferObjects.Style;

namespace Notes.Repositories.Implementation.Style
{
    public class BorderTypeRepository : NotesRepository<BorderTypeDto, BorderType>
    {
        public BorderTypeRepository(IDbContext context) : base(context)
        {
        }
    }
}
