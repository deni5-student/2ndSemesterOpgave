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
        private string _role;

        // ╔══════════════════════════════════════════════════════╗
        // ║  FORFATTER   : Dennis                                ║
        // ║  KLASSE      : Side_FlowOverview                     ║
        // ║  METODE      : Side_FlowOverview()                   ║
        // ║  BESKRIVELSE : starter siden FlowOverview            ║
        // ║                Gemmer knap for rolle elev            ║
        // ╚══════════════════════════════════════════════════════╝
        public Side_FlowOverview(string role)
        {
            InitializeComponent();
            _role = role;
            Loaded += async (s, e) => await LoadFlows();

            if (role == "Elev")
            {
                OpretFlow.Visibility = Visibility.Collapsed;
            }
        }

        // ╔══════════════════════════════════════════════════════╗
        // ║  FORFATTER   : Dennis                                ║
        // ║  KLASSE      : Side_FlowOverview                     ║
        // ║  METODE      : LoadFlows()                           ║
        // ║  BESKRIVELSE : henter alle Flows                     ║
        // ║                                                      ║
        // ╚══════════════════════════════════════════════════════╝
        private async Task LoadFlows()
        {
            FlowList.ItemsSource = await CRUD_Flow.GetAll();
        }

        // ╔══════════════════════════════════════════════════════╗
        // ║  FORFATTER   : Dennis                                ║
        // ║  KLASSE      : Side_FlowOverview                     ║
        // ║  METODE      : OpretFlow_Click()                     ║
        // ║  BESKRIVELSE : starter popup til oprettelse af Flow  ║
        // ║                                                      ║
        // ╚══════════════════════════════════════════════════════╝
        private async void OpretFlow_Click(object sender, RoutedEventArgs e)
        {
            var popup = new Popup_Flow();
            popup.ShowDialog();
            await LoadFlows();
        }

        // ╔══════════════════════════════════════════════════════╗
        // ║  FORFATTER   : Dennis                                ║
        // ║  KLASSE      : Side_FlowOverview                     ║
        // ║  METODE      : OpenFlow_Click()                      ║
        // ║  BESKRIVELSE : åbner den valgte Flow                 ║
        // ║                                                      ║
        // ╚══════════════════════════════════════════════════════╝
        private void OpenFlow_Click(object sender, RoutedEventArgs e)
        {
            if (FlowList.SelectedItem is Flow selectedFlow)
            {
                var mainWindow = (MainWindow)Window.GetWindow(this);
                mainWindow.MainContent.Content = new Side_Flow(selectedFlow, _role);
            }
            else
            {
                MessageBox.Show("Vælg en flow først.");
            }
        }

        // ╔══════════════════════════════════════════════════════╗
        // ║  FORFATTER   : Dennis                                ║
        // ║  KLASSE      : Side_FlowOverview                     ║
        // ║  METODE      : Favorit_Click()                       ║
        // ║  BESKRIVELSE : markere en flow som favorit           ║
        // ║                ændre dens udseende med '*' foran     ║
        // ╚══════════════════════════════════════════════════════╝
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
                MessageBox.Show("Vælg en flow først.");
            }
        }

        // ╔══════════════════════════════════════════════════════╗
        // ║  FORFATTER   : Dennis                                ║
        // ║  KLASSE      : Side_FlowOverview                     ║
        // ║  METODE      : InsertionSort()                       ║
        // ║  BESKRIVELSE : sotere flow liste alfabetisk          ║
        // ║                ascending = true er A-Z og omvendt    ║
        // ╚══════════════════════════════════════════════════════╝
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

        // ╔══════════════════════════════════════════════════════╗
        // ║  FORFATTER   : Dennis                                ║
        // ║  KLASSE      : Side_FlowOverview                     ║
        // ║  METODE      : AtilZ_Click()                         ║
        // ║  BESKRIVELSE : anvender InsertionSort til at sorter  ║
        // ║                                                      ║
        // ╚══════════════════════════════════════════════════════╝
        private async void AtilZ_Click(object sender, RoutedEventArgs e)
        {
            var flows = await CRUD_Flow.GetAll();
            FlowList.ItemsSource = InsertionSort(flows, true);
        }

        // ╔══════════════════════════════════════════════════════╗
        // ║  FORFATTER   : Dennis                                ║
        // ║  KLASSE      : Side_FlowOverview                     ║
        // ║  METODE      : AtilZ_Click()                         ║
        // ║  BESKRIVELSE : anvender InsertionSort til at sorter  ║
        // ║                den anden vej                         ║
        // ╚══════════════════════════════════════════════════════╝
        private async void ZtilA_Click(object sender, RoutedEventArgs e)
        {
            var flows = await CRUD_Flow.GetAll();
            FlowList.ItemsSource = InsertionSort(flows, false);
        }

        // ╔══════════════════════════════════════════════════════╗
        // ║  FORFATTER   : Dennis                                ║
        // ║  KLASSE      : Side_FlowOverview                     ║
        // ║  METODE      : Logud_Click()                         ║
        // ║  BESKRIVELSE : sender bruger tilbage til login side  ║
        // ║                                                      ║
        // ╚══════════════════════════════════════════════════════╝
        private void Logud_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.MainContent.Content = new Side_Login();
        }
    }
}
