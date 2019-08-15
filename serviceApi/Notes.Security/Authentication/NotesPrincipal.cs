using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Security.Authentication
{
    public class NotesPrincipal : IPrincipal
    {
        private NotesIdentity _Identity;

        public NotesIdentity Identity
        {
            get { return _Identity ?? new AnonymousIdentity(); }
            set { _Identity = value; }
        }

        IIdentity IPrincipal.Identity { get { return this.Identity; } }

        public bool IsInRole(string role)
        {
            return _Identity.Roles.Any(r => r == role);
        }
    }
}
