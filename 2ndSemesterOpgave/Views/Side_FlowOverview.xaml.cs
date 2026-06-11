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
            Loaded += async (s, e) => await LoadFlows();
        }

        private async Task LoadFlows()
        {
            FlowList.ItemsSource = await CRUD_Flow.GetAll();
        }

        private async void OpretFlow_Click(object sender, RoutedEventArgs e)
        {
            var popup = new Popup_Flow();
            popup.ShowDialog();
            await LoadFlows();
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

        private void Favorit_Click(object sender, RoutedEventArgs e)
        {
            if (FlowList.SelectedItem is Flow selectedFlow)
            {
                if (!selectedFlow.Title.StartsWith("* "))
                {
                    selectedFlow.Title = "* " + selectedFlow.Title;
                    var flows = FlowList.ItemsSource as List<Flow>;
                    FlowList.ItemsSource = null;
                    FlowList.ItemsSource = flows;
                }
                else
                {
                    selectedFlow.Title = selectedFlow.Title.Substring(2);
                    var flows = FlowList.ItemsSource as List<Flow>;
                    FlowList.ItemsSource = null;
                    FlowList.ItemsSource = flows;
                }
            }
            else
            {
                MessageBox.Show("Vælg et flow fra listen først.");
            }
        }

        private List<Flow> InsertionSort(List<Flow> flows, bool ascending)
        {
            for (int i = 1; i < flows.Count; i++)
            {
                Flow current = flows[i];
                int j = i - 1;

                while (j >= 0 && string.Compare(flows[j].Title, current.Title) > 0 == ascending)
                {
                    flows[j + 1] = flows[j];
                    j--;
                }
                flows[j + 1] = current;
            }
            return flows;
        }

        private async void AtilZ_Click(object sender, RoutedEventArgs e)
        {
            var flows = await CRUD_Flow.GetAll();
            FlowList.ItemsSource = InsertionSort(flows, true);
        }

        private async void ZtilA_Click(object sender, RoutedEventArgs e)
        {
            var flows = await CRUD_Flow.GetAll();
            FlowList.ItemsSource = InsertionSort(flows, false);
        }

        private void Logud_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.MainContent.Content = new Side_Login();
        }
    }
}
