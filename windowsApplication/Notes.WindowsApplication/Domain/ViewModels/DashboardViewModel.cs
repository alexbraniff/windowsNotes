using Notes.BusinessObjects.DataTransferObjects.Notes;
using Notes.BusinessObjects.DataTransferObjects.Organizations;
using Notes.BusinessObjects.DataTransferObjects.Projects;
using Notes.BusinessObjects.DataTransferObjects.Users;
using System.Collections.Generic;
using System;

namespace Notes.UI.Domain.ViewModels
{
    public class DashboardViewModel
    {
        public UserDto User { get; set; }

        public List<NoteDto> UserNotes { get; set; }

        public List<OrganizationDto> Organizations { get; set; }

        public List<ProjectDto> Projects { get; set; }
    }
}
