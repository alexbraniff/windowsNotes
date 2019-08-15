using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Security.Authentication
{
    public class NotesIdentity : IIdentity
    {
        public string Name { get; private set; }

        public string AuthenticationType { get { return "Custom Authentication"; } }

        public bool IsAuthenticated { get { return !string.IsNullOrEmpty(Name); } }

        public ICollection<string> Roles { get; private set; }

        public NotesIdentity(string name, ICollection<string> roles)
        {
            Name = name;
            Roles = roles;
        }
    }
}
