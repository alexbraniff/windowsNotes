using Notes.BusinessObjects.DataTransferObjects.Users;
using Notes.UI.Domain.Events;
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
    /// Interaction logic for UserFragment.xaml
    /// </summary>
    public partial class UserFragment : UserControl
    {
        public event EventHandler<EventArgs> UserLoggedOut;

        private UserDto User { get; set; }

        public UserFragment()
        {
            InitializeComponent();
        }
        
        public void OnUserAuthenticated(object sender, AuthenticationEventArgs e)
        {
            User = e.User;
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            UserLoggedOut?.Invoke(this, null);
        }

        private void User_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
