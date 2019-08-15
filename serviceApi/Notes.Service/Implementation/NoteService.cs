using Notes.Service.Infrastructure;
using Notes.Data.Infrastructure;
using Notes.Data.Implementation;
using System.Linq;
using System.Collections.Generic;
using Notes.Data.Model.Audit;
using Notes.Data.Model.Notes;
using AutoMapper;
using Notes.BusinessObjects.DataTransferObjects.Notes;
using Notes.BusinessObjects.DataTransferObjects.Users;

namespace Notes.Service.Implementation
{
    public class NoteService : INoteService
    {
        private IDbContext Context { get; set; }

        public NoteService(IDbContext context)
        {
            Context = context;
        }

        public List<NoteDto> All(UserDto user)
        {
            return ((NotesContext)Context).Notes.Where(e => !e.IsRemoved && Context.Set<AuditAdd>().Any(a => a.Entity == GetType().Name && a.EntityId == e.Id && a.User.Id == user.Id)) as List<NoteDto>;
        }

        public NoteDto InsertNote()
        {
            NoteDto note = Mapper.Map<NoteDto>(((NotesContext)Context).Notes.Add(new Note()));
            Context.SaveChanges();
            return note;
        }

        public NoteDto UpdateNote(NoteDto note)
        {
            NoteDto result = Mapper.Map<NoteDto>(((NotesContext)Context).Notes.Attach(Mapper.Map<Note>(note)));
            Context.SaveChanges();
            return result;
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
