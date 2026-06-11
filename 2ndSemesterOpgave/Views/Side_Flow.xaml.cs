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
using _2ndSemesterOpgave.Class;
using _2ndSemesterOpgave.Services;

namespace _2ndSemesterOpgave.Views
{
    /// <summary>
    /// Interaction logic for Side_Flow.xaml
    /// </summary>
    public partial class Side_Flow : UserControl
    {
        private Flow _currentFlow;
        public Side_Flow(Flow flow)
        {
            InitializeComponent();
            _currentFlow = flow;

            FlowTitel_TextBlock.Text = flow.Title;
            FlowText_TextBlock.Text = flow.Content;

            LoadUnderFlows();
        }

        private void LoadUnderFlows()
        {
            var underflows = CRUD_UnderFlow.GetByFlow(_currentFlow.Id);
            FlowTree.ItemsSource = underflows;
            FlowTree.DisplayMemberPath = "Title";
        }

        private void TilbageFlowOverview_Click (object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.MainContent.Content = new Side_FlowOverview();
        }

        private void OpretUnderFlow_Click(object sender, RoutedEventArgs e)
        {
            var popup = new Popup_UnderFlow(_currentFlow.Id);
            popup.ShowDialog();
            LoadUnderFlows();
        }

        private void LoadUnderFlow_Click(object sender, RoutedEventArgs e)
        {
            if (FlowTree.SelectedItem is UnderFlow selectedUnderFlow)
            {
                FlowTitel_TextBlock.Text = selectedUnderFlow.Title;
                FlowText_TextBlock.Text = selectedUnderFlow.Content;
            }
            else
            {
                MessageBox.Show("Vælg en UnderFlow først");
            }
        }

        private void Logud_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.MainContent.Content = new Side_Login();
        }
    }
}
