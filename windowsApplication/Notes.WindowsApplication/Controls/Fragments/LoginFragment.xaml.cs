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
    /// Interaction logic for LoginFragment.xaml
    /// </summary>
    public partial class LoginFragment : UserControl
    {
        public event EventHandler<AuthenticationEventArgs> UserAuthenticated;

        public LoginFragment()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            ToggleError(null);

            string name = TextBox_Name.Text;
            string password = TextBox_Password.Password;

            try
            {
                AuthenticationModel authModel = NotesApi.GetAuthenticationModel(name, password);

                IRestResponse<UserDto> response = NotesApi.Execute<UserDto>("Authentication/Login", Method.POST, authModel);

                UserDto result = NotesApi.GetData(response);

                if (string.IsNullOrEmpty(result.Token))
                {
                    throw new Exception("Failed to login");
                }

                UserAuthenticated?.Invoke(this, new AuthenticationEventArgs
                {
                    User = result
                });
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
                TextBlock_Error.Text = string.Empty;
                TextBlock_Error.Visibility = Visibility.Collapsed;
            }
            else
            {
                TextBlock_Error.Text = message;
                TextBlock_Error.Visibility = Visibility.Visible;
            }
        }
    }
}
