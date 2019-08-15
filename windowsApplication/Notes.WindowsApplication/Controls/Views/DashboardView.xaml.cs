using Notes.BusinessObjects.DataTransferObjects.Notes;
using Notes.BusinessObjects.DataTransferObjects.Organizations;
using Notes.UI.Apis;
using Notes.UI.Controls.Fragments;
using Notes.UI.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Notes.UI.Controls.Views
{
    /// <summary>
    /// Interaction logic for DashboardControl.xaml
    /// </summary>
    public partial class DashboardView : UserControl
    {
        private DashboardViewModel Model { get; set; }

        private List<NoteFragment> NoteControls { get; set; }

        public DashboardView()
        {
            InitializeComponent();
        }

        public override void BeginInit()
        {
            base.BeginInit();

            NoteControls = new List<NoteFragment>();
        }

        protected override void OnInitialized(EventArgs e)
        {
            try
            {
                List<NoteDto> notes = NotesApi.GetData(NotesApi.Execute<List<NoteDto>>("Dashboard/Notes", RestSharp.Method.GET));
                if (notes.Count() > 0)
                {
                    foreach (NoteDto note in notes)
                    {
                        NoteFragment noteControl = new NoteFragment(note);
                        noteControl.DataContext = noteControl;
                        //noteControl.ToggleEdit(true);
                        NoteControls.Add(noteControl);
                    }
                    List_Notes.ItemsSource = NoteControls;
                    List_Organizations.ItemsSource = NoteControls;
                    List_Projects.ItemsSource = NoteControls;
                }

                //List<OrganizationDto> organizations = NotesApi.GetData(NotesApi.Execute<List<OrganizationDto>>("Dashboard/Organizations", RestSharp.Method.GET));
                //if (organizations.Count() > 0)
                //{
                //    foreach (OrganizationDto organization in organizations)
                //    {
                //        OrganizationFragment organizationControl = new OrganizationFragment(organization);
                //        organizationControl.DataContext = organizationControl;
                //        //organizationControl.ToggleEdit(true);
                //        OrganizationControls.Add(organizationControl);
                //    }
                //    List_Organizations.ItemsSource = OrganizationControls;
                //    List_Organizations.ItemsSource = OrganizationControls;
                //    List_Projects.ItemsSource = OrganizationControls;
                //}

                //List<ProjectDto> projects = NotesApi.GetData(NotesApi.Execute<List<ProjectDto>>("Dashboard/Projects", RestSharp.Method.GET));
                //if (projects.Count() > 0)
                //{
                //    foreach (ProjectDto project in projects)
                //    {
                //        ProjectFragment projectControl = new ProjectFragment(project);
                //        projectControl.DataContext = projectControl;
                //        //projectControl.ToggleEdit(true);
                //        ProjectControls.Add(projectControl);
                //    }
                //    List_Projects.ItemsSource = ProjectControls;
                //    List_Organizations.ItemsSource = ProjectControls;
                //    List_Projects.ItemsSource = ProjectControls;
                //}
            }
            catch (Exception x)
            {
                ;
            }

            base.OnInitialized(e);
        }

        private void Button_AddNote_Click(object sender, RoutedEventArgs e)
        {
            //using (AuthenticationService auth = (AuthenticationService)DependencyFactory.Resolve<IAuthenticationService>())
            //{
            //    UserModel u2 = auth.Ping(User.Token);

            //    using (NoteService notes = (NoteService)DependencyFactory.Resolve<INoteService>())
            //    {
            //        NoteModel n = notes.InsertNote();

            //        NoteControl noteControl = new NoteControl(n);
            //        noteControl.ToggleEdit(true);
            //        ListView_Notes.Items.Add(noteControl);
            //    }
            //}
        }
    }
}
