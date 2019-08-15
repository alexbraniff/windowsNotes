using System.Windows;
using System.Collections.Generic;
using Notes.BusinessObjects.DataTransferObjects.Users;
using Notes.BusinessObjects.DataTransferObjects.Organizations;
using Notes.BusinessObjects.DataTransferObjects.Projects;
using Notes.BusinessObjects.DataTransferObjects.Notes;
using System.ComponentModel;
using Notes.UI.Apis;
using Notes.UI.Windows.Infrastructure;
using MaterialDesignThemes.Wpf;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Input;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using Notes.UI.Domain;
using System;
using System.Diagnostics;
using Notes.UI.Controls.Views;
using Notes.UI.Domain.Events;
using Notes.UI.Controls.Dialogs;
using Notes.UI.Domain.Models;
using System.Linq;
using Notes.UI.Domain.ViewModels.Main;
using Notes.UI.Domain.ViewModels;

namespace Notes.UI.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Snackbar Snackbar;

        private HomeView Home { get; set; }

        private DashboardView Dashboard { get; set; }

        public Visibility ViewHasLinks
        {
            get
            {
                return ListBox_MainMenuItems != null && ListBox_MainMenuItems.HasItems ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        //private LoginWindow Login { get; set; }

        //private RegisterWindow Register { get; set; }

        public MainWindow() : base()
        {
            InitializeComponent();

            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(2500);
            }).ContinueWith(t =>
            {
                //note you can use the message queue from any thread, but just for the demo here we 
                //need to get the message queue from the snackbar, so need to be on the dispatcher
                MainSnackbar.MessageQueue.Enqueue("Welcome to Material Design In XAML Tookit");
            }, TaskScheduler.FromCurrentSynchronizationContext());

            DataContext = new MainWindowViewModel(MainSnackbar.MessageQueue);

            Home = ((MainMenuItemModel<HomeView>)((MainWindowViewModel)DataContext).MainMenuItems.SingleOrDefault(i => typeof(MainMenuItemModel<HomeView>).IsAssignableFrom(i.GetType())))?.Content;
            Home.UserAuthenticated += OnUserAuthenticated;
            Home.UserLoggedOut += OnUserLogout;

            Snackbar = this.MainSnackbar;

            AccountMenu.UserAuthenticated += OnUserAuthenticated;
            AccountMenu.UserLoggedOut += OnUserLogout;

            //Login = loginWindow;
            //Register = registerWindow;
        }

        private void OnWindowClosing_Hide(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            ((Window)sender).Visibility = Visibility.Collapsed;
            if (typeof(IResetable).IsAssignableFrom(sender.GetType()))
            {
                ((IResetable)sender).Reset();
            }
        }

        private void OnUserAuthenticated(object sender, AuthenticationEventArgs e)
        {
            UserDto user = e.User;
            ((App)Application.Current).User = user;
            NotesApi.SetToken(user.Token);

            //Label_LoginDebug.Content = string.Format("Logged in as {0}", user.Name);
            //Label_LoginDebug.Visibility = Visibility.Visible;

            //Button_Register.Visibility = Visibility.Collapsed;
            //Button_Login.Visibility = Visibility.Collapsed;

            DashboardViewModel dashboardModel = new DashboardViewModel
            {
                Organizations = new List<OrganizationDto>(),
                Projects = new List<ProjectDto>(),
                UserNotes = new List<NoteDto>()
            };

            Home.Grid_NoUser.Visibility = Visibility.Collapsed;
            Home.Grid_WithUser.Visibility = Visibility.Visible;

            AccountMenu.Login.Visibility = Visibility.Collapsed;
            AccountMenu.Register.Visibility = Visibility.Collapsed;
            
            AccountMenu.User.Visibility = Visibility.Visible;

            Dashboard = new DashboardView();
            //MainGrid.Children.Add(Dashboard);
            //MainWindowControls.Visibility = Visibility.Collapsed;
        }

        private void OnUserLogout(object sender, EventArgs e)
        {
            ((App)Application.Current).User = null;
            NotesApi.SetToken(null);

            AccountMenu.Login.Visibility = Visibility.Visible;
            AccountMenu.Register.Visibility = Visibility.Visible;

            AccountMenu.User.Visibility = Visibility.Collapsed;
            
            //MainGrid.Children.Add(Dashboard);
            //MainWindowControls.Visibility = Visibility.Collapsed;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Login.Closing += OnWindowClosing_Hide;
            //Login.UserAuthenticated += OnUserAuthenticated;
            //Login.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Register.Closing += OnWindowClosing_Hide;
            //Register.UserAuthenticated += OnUserAuthenticated;
            //Register.Visibility = Visibility.Visible;
        }

        private void UIElement_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //until we had a StaysOpen glag to Drawer, this will help with scroll bars
            var dependencyObject = Mouse.Captured as DependencyObject;
            while (dependencyObject != null)
            {
                if (dependencyObject is ScrollBar) return;
                dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
            }

            MenuToggleButton.IsChecked = false;
        }

        private async void MenuPopupButton_OnClick(object sender, RoutedEventArgs e)
        {
            var sampleMessageDialog = new MessageDialog
            {
                Message = { Text = ((ButtonBase)sender).Content.ToString() }
            };

            await DialogHost.Show(sampleMessageDialog, "RootDialog");
        }

        public ICommand GoodByeCommand => new BaseCommand(ExecuteGoodByeDialog);

        private async void ExecuteGoodByeDialog(object o)
        {
            //let's set up a little MVVM, cos that's what the cool kids are doing:
            var view = new CancellableDialog
            {
                DataContext = new DialogModel()
            };

            //show the dialog
            var result = await DialogHost.Show(view, "RootDialog", ClosingEventHandler);

            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }

        private void ClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            Console.WriteLine("You can intercept the closing event, and cancel here.");
        }

        private void OnCopy(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Parameter is string stringValue)
            {
                try
                {
                    Clipboard.SetDataObject(stringValue);
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                }
            }
        }

        private bool HasShownQuitDialog { get; set; } = false;

        private async void Window_Closing(object s, CancelEventArgs e)
        {
            if (!HasShownQuitDialog)
            {
                e.Cancel = true;

                var dialog = new CancellableDialog
                {
                    Message = { Text = "Are you sure you wish to quit?" }
                };

                dialog.AcceptButton.Command = new BaseCommand(o =>
                {
                    HasShownQuitDialog = true;
                    Application.Current.Shutdown();
                });

                await DialogHost.Show(dialog, "RootDialog");

                await DialogHost.Show(dialog, delegate (object sender, DialogOpenedEventArgs args)
                {

                    args.Session.Close(false);
                });
            }
        }

        private void Button_Click_2(object s, EventArgs e)
        {
            Window_Closing(s, new CancelEventArgs());
        }
    }
}
