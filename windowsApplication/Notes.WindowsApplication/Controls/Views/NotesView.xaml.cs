using Notes.BusinessObjects.DataTransferObjects.Notes;
using Notes.UI.Apis;
using Notes.UI.Controls.Fragments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Notes.UI.Controls.Views
{
    /// <summary>
    /// Interaction logic for NotesView.xaml
    /// </summary>
    public partial class NotesView : UserControl
    {
        public NotesView()
        {
            InitializeComponent();
        }

        public List<NoteFragment> NoteControls { get; private set; }

        public override void BeginInit()
        {
            base.BeginInit();
        }

        protected override void OnInitialized(EventArgs e)
        {
            try
            {
                NoteControls = new List<NoteFragment>();
                List_Notes.ItemsSource = NoteControls;

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
                    List_Notes.Items.Refresh();
                }
            }
            catch (Exception x)
            {
                ;
            }

            base.OnInitialized(e);
        } 

        private void Button_AddNote_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NoteDto note = NotesApi.GetData(NotesApi.Execute<NoteDto>("Dashboard/CreateNote", RestSharp.Method.GET));
                if (note != null)
                {
                    NoteFragment noteControl = new NoteFragment(note);
                    noteControl.DataContext = noteControl;
                    noteControl.ToggleEdit(true);
                    NoteControls.Add(noteControl);
                    List_Notes.Items.Refresh();
                }
            }
            catch (Exception x)
            {
                ;
            }
        }
    }
}
