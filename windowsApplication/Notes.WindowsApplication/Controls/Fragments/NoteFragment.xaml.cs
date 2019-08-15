using Notes.BusinessObjects;
using Notes.BusinessObjects.DataTransferObjects.Notes;
using Notes.UI.Apis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Notes.UI.Controls.Fragments
{
    /// <summary>
    /// Interaction logic for NoteControl.xaml
    /// </summary>
    public partial class NoteFragment : UserControl
    {
        public NoteDto Note { get; set; }

        public NoteFragment() : this(new NoteDto()) { }

        public NoteFragment(NoteDto note)
        {
            Note = note;

            CommandBindings.Add(new CommandBinding(NavigationCommands.GoToPage, (sender, e) => Process.Start((string)e.Parameter)));

            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            TextBox_Title.Text = Note.Title;
            TextBox_Content.Text = Note.Content;
            base.OnInitialized(e);
        }

        private void Viewer_Content_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ToggleEdit(true);
        }

        public void ToggleEdit(bool Visible)
        {
            if (Visible)
            {
                Viewer_Content.Visibility = Visibility.Collapsed;
                TextBox_Content.Visibility = Visibility.Visible;

                Viewer_Title.Visibility = Visibility.Collapsed;
                TextBox_Title.Visibility = Visibility.Visible;

                Grid_Controls.Visibility = Visibility.Visible;
            }
            else
            {
                Viewer_Content.Visibility = Visibility.Visible;
                TextBox_Content.Visibility = Visibility.Collapsed;

                Viewer_Title.Visibility = Visibility.Visible;
                TextBox_Title.Visibility = Visibility.Collapsed;

                Grid_Controls.Visibility = Visibility.Collapsed;

                UpdateNote();
            }
        }

        private void UpdateNote()
        {
            Note.Title = TextBox_Title.Text;
            Note.Content = TextBox_Content.Text;
            NoteDto note = Note;
            note = NotesApi.GetData(NotesApi.Execute<NoteDto>("Dashboard/UpdateNote", RestSharp.Method.POST, note));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ToggleEdit(false);
        }
    }
}
