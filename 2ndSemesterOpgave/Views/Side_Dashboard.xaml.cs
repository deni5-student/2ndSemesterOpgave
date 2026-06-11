using _2ndSemesterOpgave.Services;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using _2ndSemesterOpgave.Class;

namespace _2ndSemesterOpgave.Views
{
    /// <summary>
    /// Interaction logic for Side_Dashboard.xaml
    /// </summary>
    public partial class Side_Dashboard : UserControl
    {
        public Side_Dashboard()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            UserListbox.ItemsSource = CRUD_User.GetAll();
            UserListbox.DisplayMemberPath = "Name";
        }

        private void CreateUser_Click(object sender, RoutedEventArgs e)
        {
            var popup = new Popup_User();
            popup.ShowDialog();
            LoadUsers();
        }

        private void EditUser_Click(object sender, RoutedEventArgs e)
        {
            if (UserListbox.SelectedItem is User seletecdUser)
            {
                var popup = new Popup_User(seletecdUser);
                popup.ShowDialog();
                LoadUsers();
            }
            else
            {
                MessageBox.Show("Vælg en bruger fra listen");
            }
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (UserListbox.SelectedItem is User selectedUser)
                {
                CRUD_User.Delete(selectedUser.Id);
                LoadUsers();
                }
            else
            {
                MessageBox.Show("Vælg en bruger fra listen");
            }
        }

        private void Logud_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.MainContent.Content = new Side_Login();
        }
    }
}
