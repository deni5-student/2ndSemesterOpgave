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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _2ndSemesterOpgave.Views
{
    /// <summary>
    /// Interaction logic for Side_FlowOverview.xaml
    /// </summary>
    public partial class Side_FlowOverview : UserControl
    {
        public Side_FlowOverview()
        {
            InitializeComponent();
            LoadFlows();
        }

        private void LoadFlows()
        {
            FlowList.ItemsSource = CRUD_Flow.GetAll();
        }

        private void OpretFlow_Click(object sender, RoutedEventArgs e)
        {
            var popup = new Popup_Flow();
            popup.ShowDialog();
            LoadFlows();
        }

        private void OpenFlow_Click(object sender, RoutedEventArgs e)
        {
            if (FlowList.SelectedItem is Flow selectedFlow)
            {
                var mainWindow = (MainWindow)Window.GetWindow(this);
                mainWindow.MainContent.Content = new Side_Flow(selectedFlow);
            }
            else
            {
                MessageBox.Show("Vælg et flow fra listen først.");
            }
        }

        private void Logud_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.MainContent.Content = new Side_Login();
        }
    }
}
