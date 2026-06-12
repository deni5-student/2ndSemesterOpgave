using _2ndSemesterOpgave.Class;
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
    /// Interaction logic for Popup_User.xaml
    /// </summary>
    public partial class Popup_User : Window
    {
        private User? _editUser = null;

        // ╔══════════════════════════════════════════════════════╗
        // ║  FORFATTER   : Dennis                                ║
        // ║  KLASSE      : Popup_User                            ║
        // ║  METODE      : Popup_User()                          ║
        // ║  BESKRIVELSE : starter popup til brugeroprettelse    ║
        // ║                                                      ║
        // ╚══════════════════════════════════════════════════════╝
        public Popup_User()
        {
            InitializeComponent();
        }
        // ╔══════════════════════════════════════════════════════╗
        // ║  FORFATTER   : Dennis                                ║
        // ║  KLASSE      : Popup_User                            ║
        // ║  METODE      : Popup_User()                          ║
        // ║  BESKRIVELSE : starter popup når man skal redigere   ║
        // ║                bruger                                ║
        // ╚══════════════════════════════════════════════════════╝
        public Popup_User(User user)
        {
            InitializeComponent();
            _editUser = user;

            NameBox.Text = user.Name;
            UsernameBox.Text = user.Username;
            PasswordBox.Text = user.Password;

            if (user.Role == "Administrator") RadioAdmin.IsChecked = true;
            else if (user.Role == "Lærer") RadioLaerer.IsChecked = true;
            else if (user.Role == "Elev") RadioElev.IsChecked = true;
        }
        // ╔══════════════════════════════════════════════════════╗
        // ║  FORFATTER   : Dennis                                ║
        // ║  KLASSE      : Popup_User                            ║
        // ║  METODE      : Gem_Click()                           ║
        // ║  BESKRIVELSE : opretter eller gemmer bruger          ║
        // ║                kommer an på _editUser                ║
        // ╚══════════════════════════════════════════════════════╝
        private void Gem_Click(object sender, RoutedEventArgs e)
        {
            string name = NameBox.Text;
            string username = UsernameBox.Text;
            string password = PasswordBox.Text;
            string role = RadioAdmin.IsChecked == true ? "Administrator" : RadioLaerer.IsChecked == true ? "Lærer" : "Elev";

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Udfydl alle felter");
                return;
            }

            if (_editUser == null)
            {
                 CRUD_User.Add(name, username, password, role);
            }
            else
            {
                CRUD_User.Update(_editUser.Id, name, username, password, role);
            }

            Close();
        }
    }
}
