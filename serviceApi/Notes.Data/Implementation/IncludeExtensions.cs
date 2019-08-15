using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Data.Implementation
{
    public static class IncludeExtensions
    {
        //.Include(a => a.AddHistory)
        //.Include(a => a.UpdateHistory)
        //.Include(a => a.DeleteHistory)
        //.Include(a => a.Notes)
        //.Include(a => a.Notes.Select(b => b.Note))
        //.Include(a => a.OrganizationNoteRoles)
        //.Include(a => a.OrganizationNoteRoles.Select(b => b.OrganizationNoteRole))
        //.Include(a => a.OrganizationNoteRoles.Select(b => b.OrganizationNoteRole).Select(b => b.OrganizationNote))
        //.Include(a => a.OrganizationNoteRoles.Select(b => b.OrganizationNoteRole).Select(b => b.OrganizationNote).Select(b => b.Organization))
        //.Include(a => a.OrganizationNoteRoles.Select(b => b.OrganizationNoteRole).Select(b => b.OrganizationNote).Select(b => b.Note))
        //.Include(a => a.OrganizationNoteRoles.Select(b => b.OrganizationNoteRole).Select(b => b.Role))
        //.Include(a => a.OrganizationNotes)
        //.Include(a => a.OrganizationNotes.Select(b => b.OrganizationNote))
        //.Include(a => a.OrganizationNotes.Select(b => b.OrganizationNote).Select(b => b.Organization))
        //.Include(a => a.OrganizationNotes.Select(b => b.OrganizationNote).Select(b => b.Note))
        //.Include(a => a.OrganizationRoles)
        //.Include(a => a.OrganizationRoles.Select(b => b.OrganizationRole))
        //.Include(a => a.OrganizationRoles.Select(b => b.OrganizationRole).Select(b => b.Organization))
        //.Include(a => a.OrganizationRoles.Select(b => b.OrganizationRole).Select(b => b.Role))
        //.Include(a => a.Organizations)
        //.Include(a => a.Organizations.Select(b => b.Organization))
        //.Include(a => a.ProjectNoteRoles)
        //.Include(a => a.ProjectNoteRoles.Select(b => b.ProjectNoteRole))
        //.Include(a => a.ProjectNoteRoles.Select(b => b.ProjectNoteRole).Select(b => b.ProjectNote))
        //.Include(a => a.ProjectNoteRoles.Select(b => b.ProjectNoteRole).Select(b => b.ProjectNote).Select(b => b.Project))
        //.Include(a => a.ProjectNoteRoles.Select(b => b.ProjectNoteRole).Select(b => b.ProjectNote).Select(b => b.Note))
        //.Include(a => a.ProjectNoteRoles.Select(b => b.ProjectNoteRole).Select(b => b.Role))
        //.Include(a => a.ProjectNotes)
        //.Include(a => a.ProjectNotes.Select(b => b.ProjectNote))
        //.Include(a => a.ProjectNotes.Select(b => b.ProjectNote).Select(b => b.Project))
        //.Include(a => a.ProjectNotes.Select(b => b.ProjectNote).Select(b => b.Note))
        //.Include(a => a.ProjectRoles)
        //.Include(a => a.ProjectRoles.Select(b => b.ProjectRole))
        //.Include(a => a.ProjectRoles.Select(b => b.ProjectRole).Select(b => b.Project))
        //.Include(a => a.ProjectRoles.Select(b => b.ProjectRole).Select(b => b.Role))
        //.Include(a => a.Projects)
        //.Include(a => a.Projects.Select(b => b.Project))
        //.Include(a => a.Tags)
        //.Include(a => a.Tags.Select(b => b.Tag))
        //.Include(a => a.Style);
    }
}
