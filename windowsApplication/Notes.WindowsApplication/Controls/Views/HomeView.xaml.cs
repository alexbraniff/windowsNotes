using Notes.BusinessObjects.DataTransferObjects.Users;
using Notes.UI.Domain.Events;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Notes.UI.Controls.Views
{
    /// <summary>
    /// Interaction logic for HomeControl.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public event EventHandler<AuthenticationEventArgs> UserAuthenticated;
        public event EventHandler<EventArgs> UserLoggedOut;

        private UserDto User { get; set; }

        public HomeView() : this(null) { }

        public HomeView(UserDto user)
        {
            InitializeComponent();

            Login.UserAuthenticated += OnUserAuthenticated;
            Register.UserAuthenticated += OnUserAuthenticated;
        }

        private void OnUserAuthenticated(object sender, AuthenticationEventArgs e)
        {
            Grid_NoUser.Visibility = Visibility.Collapsed;
            Grid_WithUser.Visibility = Visibility.Visible;
            UserAuthenticated?.Invoke(sender, e);
        }

        private void OnUserLogout(object sender, EventArgs e)
        {
            Grid_NoUser.Visibility = Visibility.Visible;
            Grid_WithUser.Visibility = Visibility.Collapsed;
            UserLoggedOut?.Invoke(sender, e);
        }
    }
}
