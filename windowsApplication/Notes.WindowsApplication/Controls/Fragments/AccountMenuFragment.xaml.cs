using Notes.BusinessObjects.DataTransferObjects.Users;
using Notes.BusinessObjects.WebApiModels;
using Notes.UI.Apis;
using Notes.UI.Domain.Events;
using RestSharp;
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

namespace Notes.UI.Controls.Fragments
{
    /// <summary>
    /// Interaction logic for LoginButton.xaml
    /// </summary>
    public partial class AccountMenuFragment : UserControl
    {
        public event EventHandler<AuthenticationEventArgs> UserAuthenticated;
        public event EventHandler<EventArgs> UserLoggedOut;

        public AccountMenuFragment()
        {
            InitializeComponent();
            Login.UserAuthenticated += OnUserAuthenticated;
            Register.UserAuthenticated += OnUserAuthenticated;
            User.UserLoggedOut += OnUserLogout;
        }

        private void OnUserAuthenticated(object sender, AuthenticationEventArgs e)
        {
            Popup_Account.IsPopupOpen = false;
            User.OnUserAuthenticated(sender, e);
            UserAuthenticated?.Invoke(this, e);
        }

        private void OnUserLogout(object sender, EventArgs e)
        {
            Popup_Account.IsPopupOpen = false;
            UserLoggedOut?.Invoke(this, e);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Popup_Account.IsPopupOpen = !Popup_Account.IsPopupOpen;
        }
    }
}
