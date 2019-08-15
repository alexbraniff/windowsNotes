using Notes.BusinessObjects.DataTransferObjects.Users;
using Notes.Security.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Notes.API.Helpers
{
    public static class UserHelper
    {
        public static IEnumerable<string> GetAllRoles(UserDto user)
        {
            IEnumerable<string> orgRoles = user.OrganizationRoles
                .Select(a => $"Organization-{a.OrganizationRole.OrganizationId.ToString()}:{a.OrganizationRole.RoleId.ToString()}");

            IEnumerable<string> orgNoteRoles = user.OrganizationNoteRoles
                .Select(a => $"OrganizationNote-{a.OrganizationNoteRole.OrganizationNoteId.ToString()}:{a.OrganizationNoteRole.RoleId.ToString()}");

            IEnumerable<string> projRoles = user.ProjectRoles
                .Select(a => $"Project-{a.ProjectRole.ProjectId.ToString()}:{a.ProjectRole.RoleId.ToString()}");

            IEnumerable<string> projNoteRoles = user.ProjectNoteRoles
                .Select(a => $"ProjectNote-{a.ProjectNoteRole.ProjectNoteId.ToString()}:{a.ProjectNoteRole.RoleId.ToString()}");

            return orgRoles.Concat(orgNoteRoles).Concat(projRoles).Concat(projNoteRoles);
        }

        public static IPrincipal GetPrincipal(UserDto user)
        {
            return new NotesPrincipal
            {
                Identity = new NotesIdentity(user.Name, GetAllRoles(user).ToArray())
            };
        }
    }
}