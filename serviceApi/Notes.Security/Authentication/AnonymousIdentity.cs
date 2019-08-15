using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Security.Authentication
{
    public class AnonymousIdentity : NotesIdentity
    {
        public AnonymousIdentity() : base(string.Empty, new List<string> { }) { }
    }
}
