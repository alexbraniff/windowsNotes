using Ninject;
using Notes.API.Attributes;
using Notes.API.Filters;
using Notes.BusinessObjects.DataTransferObjects.Notes;
using Notes.BusinessObjects.DataTransferObjects.Users;
using Notes.Repositories.Implementation.Notes;
using Notes.Service.Infrastructure;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace Notes.API.Areas.api.Controllers
{
    public class NoteController : ApiController
    {
        private NoteRepository Notes { get; set; }

        [Inject]
        private IAuthenticationService Authentication { get; set; }
        
        [Inject]
        public NoteController(NoteRepository notes)
        {
            Notes = notes;
        }

        private bool ShouldNoteBeDisplayedToUser(NoteDto note, UserDto user)
        {
            return IsNoteValid(note) && IsUserValid(user) && CanRead(note, user);
        }

        private bool IsNoteValid(NoteDto note)
        {
            return !note.IsRemoved;
        }

        private bool IsUserValid(UserDto user)
        {
            return !user.IsRemoved;
        }

        private bool CanRead(NoteDto note, UserDto user)
        {
            // ToDo: Check if user has permissions to read this note
            return true;
        }

        // GET: api/Dashboard
        [HttpGet]
        [HttpTokenAuthenticationAttribute]
        public IHttpActionResult Get()
        {
            NoteDto[] result = null;

            try
            {
            }
            catch (Exception x)
            {
                // TODO: Handle error
                throw x;
            }

            return Ok(result);
        }
        
    }
}