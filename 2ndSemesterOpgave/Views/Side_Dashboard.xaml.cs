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
            Loaded += async (s, e) => await LoadUsers();
        }

        private async Task LoadUsers()
        {
            UserListbox.ItemsSource = await CRUD_User.GetAll();
            UserListbox.DisplayMemberPath = "Name";
        }

        private async void CreateUser_Click(object sender, RoutedEventArgs e)
        {
            var popup = new Popup_User();
            popup.ShowDialog();
            await LoadUsers();
        }

        private async void EditUser_Click(object sender, RoutedEventArgs e)
        {
            if (UserListbox.SelectedItem is User selectedUser)
            {
                var popup = new Popup_User(selectedUser);
                popup.ShowDialog();
                await LoadUsers();
            }
            else
            {
                MessageBox.Show("Vælg en bruger fra listen først.");
            }
        }

        private async void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (UserListbox.SelectedItem is User selectedUser)
            {
                await CRUD_User.Delete(selectedUser.Id);
                await LoadUsers();
            }
            else
            {
                MessageBox.Show("Vælg en bruger fra listen først.");
            }
        }

        private void Logud_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.MainContent.Content = new Side_Login();
        }
    }
}
