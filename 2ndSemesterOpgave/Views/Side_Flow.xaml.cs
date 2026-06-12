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

        private string _role;

        // ╔══════════════════════════════════════════════════════╗
        // ║  FORFATTER   : Dennis                                ║
        // ║  KLASSE      : Side_Flow                             ║
        // ║  METODE      : Side_Flow()                           ║
        // ║  BESKRIVELSE : starter siden flow                    ║
        // ║                gemmer underflow for rolle elev       ║
        // ╚══════════════════════════════════════════════════════╝
        public Side_Flow(Flow flow, string role)
        {
            InitializeComponent();
            _currentFlow = flow;
            _role = role;

            FlowTitel_TextBlock.Text = flow.Title;
            FlowText_TextBlock.Text = flow.Content;

            Loaded += async (s, e) => await LoadUnderFlows();

            if (role == "Elev")
            {
                OpretUnderFlow.Visibility = Visibility.Collapsed;
            }
        }

        // ╔══════════════════════════════════════════════════════╗
        // ║  FORFATTER   : Dennis                                ║
        // ║  KLASSE      : Side_Flow                             ║
        // ║  METODE      : LoadUnderFlows()                      ║
        // ║  BESKRIVELSE : Henter alle Flows                     ║
        // ║                                                      ║
        // ╚══════════════════════════════════════════════════════╝
        private async Task LoadUnderFlows()
        {
            var underflows = await CRUD_UnderFlow.GetByFlow(_currentFlow.Id);
            FlowTree.ItemsSource = underflows;
            FlowTree.DisplayMemberPath = "Title";
        }

        // ╔══════════════════════════════════════════════════════╗
        // ║  FORFATTER   : Dennis                                ║
        // ║  KLASSE      : Side_Flow                             ║
        // ║  METODE      : LoadUnderFlow_Click()                 ║
        // ║  BESKRIVELSE : Henter alle UnderFlows                ║
        // ║                                                      ║
        // ╚══════════════════════════════════════════════════════╝
        private void LoadUnderFlow_Click(object sender, RoutedEventArgs e)
        {
            if (FlowTree.SelectedItem is UnderFlow selectedUnderFlow)
            {
                FlowTitel_TextBlock.Text = selectedUnderFlow.Title;
                FlowText_TextBlock.Text = selectedUnderFlow.Content;
            }
            else
            {
                MessageBox.Show("Vælg en UnderFlow først.");
            }
        }

        // ╔══════════════════════════════════════════════════════╗
        // ║  FORFATTER   : Dennis                                ║
        // ║  KLASSE      : Side_Flow                             ║
        // ║  METODE      : OpretUnderFlow_Click()                ║
        // ║  BESKRIVELSE : starter popup til oprettelse af       ║
        // ║                UnderFlow                             ║
        // ╚══════════════════════════════════════════════════════╝
        private async void OpretUnderFlow_Click(object sender, RoutedEventArgs e)
        {
            var popup = new Popup_UnderFlow(_currentFlow.Id);
            popup.ShowDialog();
            await LoadUnderFlows();
        }

        // ╔══════════════════════════════════════════════════════╗
        // ║  FORFATTER   : Dennis                                ║
        // ║  KLASSE      : Side_Flow                             ║
        // ║  METODE      : TilbageFlowOverview_Click()           ║
        // ║  BESKRIVELSE : tager dig tilbage til FlowOverview    ║
        // ║                                                      ║
        // ╚══════════════════════════════════════════════════════╝
        private void TilbageFlowOverview_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.MainContent.Content = new Side_FlowOverview(_role);
        }

        // ╔══════════════════════════════════════════════════════╗
        // ║  FORFATTER   : Dennis                                ║
        // ║  KLASSE      : Side_Flow                             ║
        // ║  METODE      : Logud_Click()                         ║
        // ║  BESKRIVELSE : tager dig tilbage til login side      ║
        // ║                                                      ║
        // ╚══════════════════════════════════════════════════════╝
        private void Logud_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.MainContent.Content = new Side_Login();
        }
    }
}
