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
    /// Interaction logic for RegisterFragment.xaml
    /// </summary>
    public partial class RegisterFragment : UserControl
    {
        public event EventHandler<AuthenticationEventArgs> UserAuthenticated;

        public RegisterFragment()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            ToggleError(null);

            string name = TextBox_Name.Text;
            string password = TextBox_Password.Password;
            string password2 = TextBox_Password2.Password;

            try
            {
                if (password != password2)
                {
                    throw new Exception("Passwords must match");
                }

                AuthenticationModel authModel = NotesApi.GetAuthenticationModel(name, password);

                IRestResponse<UserDto> response = NotesApi.Execute<UserDto>("Authentication/Register", Method.PUT, authModel);

                UserDto result = response.Data;

                if (string.IsNullOrEmpty(result.Token))
                {
                    throw new Exception("Failed to Register");
                }

                UserAuthenticated?.Invoke(this, new AuthenticationEventArgs
                {
                    User = result
                });

                Visibility = Visibility.Collapsed;
            }
            catch (Exception x)
            {
                ToggleError(x.Message);
            }
        }

        private void ToggleError(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                Label_Error.Content = string.Empty;
                Label_Error.Visibility = Visibility.Collapsed;
            }
            else
            {
                Label_Error.Content = message;
                Label_Error.Visibility = Visibility.Visible;
            }
        }
    }
}
