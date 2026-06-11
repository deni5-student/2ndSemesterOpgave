using _2ndSemesterOpgave.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _2ndSemesterOpgave.Views
{
    /// <summary>
    /// Interaction logic for Side_Login.xaml
    /// </summary>
    public partial class Side_Login : UserControl
    {
        public Side_Login()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameBox.Text;
            string password = PasswordBox.Password;

            using var connection = Database.GetConnection();
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT Role FROM User WHERE Username = @username AND Password = @password";
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);

            var role = command.ExecuteScalar() as string;

            if (role == null)
            {
                MessageBox.Show("Forkert brugernavn eller adgangskode");
                return;
            }

            var forside = (MainWindow)Window.GetWindow(this);

            if (role == "Administrator")
            {
                forside.MainContent.Content = new Side_Dashboard();
            }
            else
            {
                forside.MainContent.Content = new Side_FlowOverview();
                
            }
        }
    }
}
